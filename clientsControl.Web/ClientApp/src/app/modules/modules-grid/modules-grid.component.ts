import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { ModulesGridDataSource } from './modules-grid-datasource';
import { ModulesService } from '../../services/modules.service';
import { ModuleComponent } from '../module/module.component';
import { NotificationUiService } from '../../services/notification-ui.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-modules-grid',
  templateUrl: './modules-grid.component.html',
  styleUrls: ['./modules-grid.component.css']
})
export class ModulesGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ModulesGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['description', 'workStations', 'actions'];

  constructor(private modulesServices: ModulesService, private moduleDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new ModulesGridDataSource(this.paginator, this.sort, this.modulesServices);
  }

  onCreate() {
    this.moduleDialog.open(ModuleComponent).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onEdit(row) {
    this.moduleDialog.open(ModuleComponent, { data: { editMode : true, moduleId : row['id'] }}).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onDelete(row) {
    this.confirmDialog
      .open(ConfirmationDialogComponent, { data: { message: "¿Confirma eliminar el registro?" } })
      .afterClosed().subscribe(result => {
        this.modulesServices.deleteModule(row['id'])
          .subscribe(result => {
            this.notificacionUIService.success('Registro eliminado correctamente');
            this.refreshDataSource();
          }, error => { console.log(error) });
      });
  }  
}
