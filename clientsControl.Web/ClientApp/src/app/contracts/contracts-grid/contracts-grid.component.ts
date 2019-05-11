import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { ContractsGridDataSource } from './contracts-grid-datasource';
import { ContractsService } from '../../services/contracts.service';
import { NotificationUiService } from '../../services/notification-ui.service';
import { ContractComponent } from '../contract/contract.component';

@Component({
  selector: 'app-contracts-grid',
  templateUrl: './contracts-grid.component.html',
  styleUrls: ['./contracts-grid.component.css']
})
export class ContractsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ContractsGridDataSource;

  constructor(private contractsService: ContractsService, private contactDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }
  
  displayedColumns = ['numero', 'definition', 'client', 'fechaEntrega', 'fechaFirma', 'fechaRecibido', 'objeto', 'master', 'actions'];

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new ContractsGridDataSource(this.paginator, this.sort, this.contractsService);
  }

  onCreate() {
    const conf = new MatDialogConfig();
    conf.width = "65%";

    this.contactDialog.open(ContractComponent, conf).afterClosed().subscribe(close => { this.refreshDataSource() });
  }
}
