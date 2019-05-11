import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { IContract } from '../../interfaces/contract';
import { ContractsService } from '../../services/contracts.service';

/**
 * Data source for the ContractsGrid view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class ContractsGridDataSource extends DataSource<IContract> {
  data: IContract[];

  constructor(private paginator: MatPaginator, private sort: MatSort, private contractsService: ContractsService) {
    super();
    this.contractsService.getContracts().subscribe(contracts => { this.data = contracts; }, error => console.log(error));
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<IContract[]> {
    // Combine everything that affects the rendered data into one update
    // stream for the data-table to consume.
    const dataMutations = [
      observableOf(this.data),
      this.paginator.page,
      this.sort.sortChange
    ];

    // Set the paginator's length
    this.paginator.length = this.data.length;

    return merge(...dataMutations).pipe(map(() => {
      return this.getPagedData(this.getSortedData([...this.data]));
    }));
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: IContract[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: IContract[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'client': return compare(a.client, b.client, isAsc);
        case 'clientId': return compare(a.clientId, b.clientId, isAsc);
        case 'numero': return compare(a.numero, b.numero, isAsc);
        case 'suplemento': return compare(a.suplemento, b.suplemento, isAsc);
        case 'numeroSuplement': return compare(a.numeroSuplement, b.numeroSuplement, isAsc);
        case 'fechaEntrega': return compare(a.fechaEntrega, b.fechaEntrega, isAsc);
        case 'fechaFirma': return compare(a.fechaFirma, b.fechaFirma, isAsc);
        case 'fechaRecibido': return compare(a.fechaRecibido, b.fechaRecibido, isAsc);
        case 'instalador': return compare(a.instalador, b.instalador, isAsc);
        case 'idInstalador': return compare(a.idInstalador, b.idInstalador, isAsc);
        case 'ubicacion': return compare(a.ubicacion, b.ubicacion, isAsc);
        case 'objeto': return compare(a.objeto, b.objeto, isAsc);
        case 'importeLicenciasCUC': return compare(+a.importeLicenciasCUC, +b.importeLicenciasCUC, isAsc);
        case 'importeLicenciasMN': return compare(+a.importeLicenciasMN, +b.importeLicenciasMN, isAsc);
        case 'importePostVentaCUC': return compare(+a.importePostVentaCUC, +b.importePostVentaCUC, isAsc);
        case 'importePostVentaMN': return compare(+a.importePostVentaMN, +b.importePostVentaMN, isAsc);
        case 'inicioPostVenta': return compare(a.inicioPostVenta, b.inicioPostVenta, isAsc);
        case 'finalPostVenta': return compare(a.finalPostVenta, b.finalPostVenta, isAsc);        
        case 'master': return compare(a.suplemento, b.suplemento, isAsc);        
        case 'discontinued': return compare(a.id, b.id, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
