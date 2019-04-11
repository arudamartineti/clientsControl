import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ClientsGridDataSource } from './clients-grid-datasource';
import { ClientsService } from '../../services/clients.service';

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
  displayedColumns = ['code', 'description', 'actions'];

  constructor(private clientService: ClientsService) {        
  }

  ngOnInit() {
    this.dataSource = new ClientsGridDataSource(this.paginator, this.sort, this.clientService);
  }

  applyFilter() {
    console.log(this.filter);
  }
}
