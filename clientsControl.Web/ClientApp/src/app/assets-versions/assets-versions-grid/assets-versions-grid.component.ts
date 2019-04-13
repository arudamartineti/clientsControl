import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { AssetsVersionsGridDataSource } from './assets-versions-grid-datasource';
import { AssetsversionService } from '../../services/assetsversion.service';
import { AssetsVersionComponent } from '../assets-version/assets-version.component';
import { NotificationUiService } from '../../services/notification-ui.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-assets-versions-grid',
  templateUrl: './assets-versions-grid.component.html',
  styleUrls: ['./assets-versions-grid.component.css']
})
export class AssetsVersionsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: AssetsVersionsGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['description', 'actions'];

  constructor(public notificationService: NotificationUiService, private assetsVersionService: AssetsversionService, private assetsVersionDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new AssetsVersionsGridDataSource(this.paginator, this.sort, this.assetsVersionService);    
  }

  onCreate() {
    this.assetsVersionDialog.open(AssetsVersionComponent).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onEdit(row) {
    this.assetsVersionDialog.open(AssetsVersionComponent, { data: { editMode: true, assetsVersionId : row['id'] } }).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onDelete(row) {  
    this.confirmDialog
      .open(ConfirmationDialogComponent, { data: { message: "¿Confirma eliminar el registro?" } })
      .afterClosed().subscribe(result => {
        this.assetsVersionService.deleteAssetsVersion(row['id'])
          .subscribe(result => {
            this.notificacionUIService.success('Registro eliminado correctamente');
            this.refreshDataSource();
          }, error => { console.log(error) });
      });
    }
}
