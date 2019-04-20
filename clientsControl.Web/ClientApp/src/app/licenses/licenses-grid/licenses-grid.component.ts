import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { LicensesGridDataSource } from './licenses-grid-datasource';
import { LicenseService } from '../../services/license.service';
import { NotificationUiService } from '../../services/notification-ui.service';
import { LicenseComponent } from '../license/license.component';
import { ScrollStrategyOptions } from '@angular/cdk/overlay';

@Component({
  selector: 'app-licenses-grid',
  templateUrl: './licenses-grid.component.html',
  styleUrls: ['./licenses-grid.component.css']
})
export class LicensesGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: LicensesGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['reup', 'name', 'clientDescription', 'creationDate', 'actions'];
  constructor(private licenseService: LicenseService, private licenseDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDatasource();
  }

  refreshDatasource() {
    this.dataSource = new LicensesGridDataSource(this.paginator, this.sort, this.licenseService);
  }

  onCreate() {
    const conf = new MatDialogConfig();
    conf.width = "70%";
    conf.maxHeight = "400px";
    //conf.scrollStrategy = MAT_DIALOG_SCROLL_STRATEGY.;
    this.licenseDialog.open(LicenseComponent, conf).afterClosed().subscribe(close => { this.refreshDatasource(); });
  }



  onEdit(row) {
    const conf = new MatDialogConfig();
    conf.width = "70%";
    conf.maxHeight = "400px";    
    conf.data = { editMode: true, licenseId: row['id'] };
    
    this.licenseDialog.open(LicenseComponent, conf).afterClosed().subscribe(close => { this.refreshDatasource(); });
  }

  onDelete() {

  }

}
