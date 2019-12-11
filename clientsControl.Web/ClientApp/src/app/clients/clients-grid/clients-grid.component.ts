import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ClientsGridDataSource } from './clients-grid-datasource';
import { ClientsService } from '../../services/clients.service';
import { MatDialog, MatDialogConfig } from '@angular/material'
import { ClientComponent } from '../client/client.component';

@Component({
  selector: 'app-clients-grid',
  templateUrl: './clients-grid.component.html',
  styleUrls: ['./clients-grid.component.css']
})
export class ClientsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ClientsGridDataSource;
  filter: string;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['code', 'description', 'assetsCode', 'nombrecorto', 'actions'];

  constructor(private clientService: ClientsService, private clientDialog: MatDialog) {        
  }

  ngOnInit() {
    this.dataSource = new ClientsGridDataSource(this.paginator, this.sort, this.clientService);    
  }

  applyFilter() {
    
  }

  onClearFilter() {
    this.filter = "";
  }

  create() {
    const config = new MatDialogConfig();
    config.width = "300px";
    this.clientDialog.open(ClientComponent, config).afterClosed().subscribe(value => { this.refreshDataSource() });
  }


  refreshDataSource() {
    this.dataSource = new ClientsGridDataSource(this.paginator, this.sort, this.clientService); 
  }

  closeCreateDialog() {
    
  }

  onDelete(row) {
    this.clientService.deleteClient(row['id']).subscribe(response => {
        this.refreshDataSource();
      }, error => console.log(error));
  }

  onEdit(row) {    
    this.clientDialog.open(ClientComponent, { data: { editMode: true, clientId: row['id'] } }).afterClosed().subscribe(value => { this.refreshDataSource() });
  }
}
