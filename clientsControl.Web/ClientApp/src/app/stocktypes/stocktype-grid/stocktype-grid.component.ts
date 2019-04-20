import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { StocktypeGridDataSource } from './stocktype-grid-datasource';
import { StocktypesService } from '../../services/stocktypes.service';
import { StocktypeComponent } from '../stocktype/stocktype.component';
import { NotificationUiService } from '../../services/notification-ui.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-stocktype-grid',
  templateUrl: './stocktype-grid.component.html',
  styleUrls: ['./stocktype-grid.component.css']
})
export class StocktypeGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: StocktypeGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['description', 'workStations', 'actions'];

  constructor(private stockTypesService: StocktypesService, public notificationService: NotificationUiService, private assetsVersionDialog: MatDialog, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new StocktypeGridDataSource(this.paginator, this.sort, this.stockTypesService);
  }

  onCreate() {
    this.assetsVersionDialog.open(StocktypeComponent).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onEdit(row) {
    this.assetsVersionDialog.open(StocktypeComponent, { data: { editMode: true, stockTypeId: row['id'] } }).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onDelete(row) {
    this.confirmDialog
      .open(ConfirmationDialogComponent, { data: { message: "¿Confirma eliminar el registro?" } })
      .afterClosed().subscribe(result => {
        this.stockTypesService.deleteStockType(row['id'])
          .subscribe(result => {
            this.notificationService.success('Registro eliminado correctamente');
            this.refreshDataSource();
          }, error => { console.log(error) });
      });
  }
}
