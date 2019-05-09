import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ContractsGridDataSource } from './contracts-grid-datasource';
import { ContractsService } from '../../services/contracts.service';

@Component({
  selector: 'app-contracts-grid',
  templateUrl: './contracts-grid.component.html',
  styleUrls: ['./contracts-grid.component.css']
})
export class ContractsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ContractsGridDataSource;

  constructor(private contractsService: ContractsService) { }
  
  displayedColumns = ['numero', 'definition', 'client', 'fechaEntrega', 'fechaFirma', 'fechaRecibido', 'objeto', 'master', 'actions'];

  ngOnInit() {
    this.dataSource = new ContractsGridDataSource(this.paginator, this.sort, this.contractsService);
  }
}
