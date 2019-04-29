import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { UsersGridDataSource } from './users-grid-datasource';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-users-grid',
  templateUrl: './users-grid.component.html',
  styleUrls: ['./users-grid.component.css']
})
export class UsersGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: UsersGridDataSource;

  constructor(private userService : UsersService) { }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['userName', 'fullName', 'actions'];

  ngOnInit() {
    this.refreshDataSource();
  }

  refreshDataSource() {
    this.dataSource = new UsersGridDataSource(this.paginator, this.sort, this.userService);
  }
}
