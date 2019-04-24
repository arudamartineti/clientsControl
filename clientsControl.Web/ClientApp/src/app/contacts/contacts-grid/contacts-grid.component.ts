import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig } from '@angular/material';
import { ContactsGridDataSource } from './contacts-grid-datasource';
import { ContactsService } from '../../services/contacts.service';
import { ContactComponent } from '../contact/contact.component';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-contacts-grid',
  templateUrl: './contacts-grid.component.html',
  styleUrls: ['./contacts-grid.component.css']
})
export class ContactsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ContactsGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['name', 'phoneNumber', 'email', 'clientDescription', 'licenseName', 'actions'];

  constructor(private contactsService: ContactsService, private contactDialog: MatDialog, private notificacionUIService: NotificationUiService, private confirmDialog: MatDialog) { }

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new ContactsGridDataSource(this.paginator, this.sort, this.contactsService);
  }

  onCreate() {
    const conf = new MatDialogConfig();
    conf.width = "40%";

    this.contactDialog.open(ContactComponent, conf).afterClosed().subscribe(close => { this.refreshDataSource() });
  }

  onEdit() {
  }

  onDelete() {
  }
}
