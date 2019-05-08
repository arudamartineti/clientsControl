import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ContractsGridDataSource } from './contracts-grid-datasource';

@Component({
  selector: 'app-contracts-grid',
  templateUrl: './contracts-grid.component.html',
  styleUrls: ['./contracts-grid.component.css']
})
export class ContractsGridComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ContractsGridDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngAfterViewInit() {
    this.dataSource = new ContractsGridDataSource(this.paginator, this.sort);
  }
}
