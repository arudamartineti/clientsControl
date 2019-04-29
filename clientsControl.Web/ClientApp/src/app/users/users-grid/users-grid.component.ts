import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { UsersGridDataSource } from './users-grid-datasource';
import { UsersService } from '../../services/users.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-users-grid',
  templateUrl: './users-grid.component.html',
  styleUrls: ['./users-grid.component.css']
})
export class UsersGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: UsersGridDataSource;

  constructor(private userService: UsersService, private confirmDialog: MatDialog, private notificacionUIService: NotificationUiService) { }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['userName', 'fullName', 'actions'];

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new UsersGridDataSource(this.paginator, this.sort, this.userService);
  }

  onAuthorize(row) {
    this.confirmDialog
      .open(ConfirmationDialogComponent, { data: { message: "¿Confirma autorizar el usuario?" } })
      .afterClosed().subscribe(result => {
        this.userService.authorizeUser(row['id'], row)
          .subscribe(result => {
            this.notificacionUIService.success('Usuario autorizado correctamente');
            this.refreshDataSource();
          }, error => { console.log(error) });
      });
  }
}
