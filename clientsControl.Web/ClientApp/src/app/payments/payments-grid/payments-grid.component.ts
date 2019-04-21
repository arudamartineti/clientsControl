import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { PaymentsGridDataSource } from './payments-grid-datasource';
import { NotificationUiService } from '../../services/notification-ui.service';
import { PaymentControlService } from '../../services/payment-control.service';
import { PaymentComponent } from '../payment/payment.component';
import { PaymentClientComponent } from '../payment-client/payment-client.component';

@Component({
  selector: 'app-payments-grid',
  templateUrl: './payments-grid.component.html',
  styleUrls: ['./payments-grid.component.css']
})
export class PaymentsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: PaymentsGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['licenseName', 'clientDescription', 'expirationDate'];
  constructor(private paymentControlService: PaymentControlService, private paymentControlDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new PaymentsGridDataSource(this.paginator, this.sort, this.paymentControlService);
  }

  onCreate() {
    const conf = new MatDialogConfig();
    conf.width = "40%";
    this.paymentControlDialog.open(PaymentComponent, conf).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onCreateClient() {
    const conf = new MatDialogConfig();
    conf.width = "40%";
    this.paymentControlDialog.open(PaymentClientComponent, conf).afterClosed().subscribe(close => { this.refreshDataSource() });
  }
}
