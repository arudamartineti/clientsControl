import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { ILicense } from '../../interfaces/license';
import { LicenseService } from '../../services/license.service';


export class LicensesGridDataSource extends DataSource<ILicense> {
  data: ILicense[];

  constructor(private paginator: MatPaginator, private sort: MatSort, private licenseService: LicenseService) {
    super();
    licenseService.getLicenses().subscribe(licenses => { this.data = licenses }, error => { console.log(error) });
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<ILicense[]> {
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
  private getPagedData(data: ILicense[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: ILicense[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'reup': return compare(a.reup, b.reup, isAsc);
        case 'name': return compare(a.name, b.name, isAsc);
        case 'code': return compare(a.code, b.code, isAsc);
        case 'creationDate': return compare(a.creationDate, b.creationDate, isAsc);
        case 'descontinued': return compare(a.descontinued, b.descontinued, isAsc);
        case 'clientId': return compare(a.clientId, b.clientId, isAsc);
        case 'versionId': return compare(a.versionId, b.versionId, isAsc);
        case 'stockTypeId': return compare(a.stockTypeId, b.stockTypeId, isAsc);
        case 'clasificationId': return compare(a.clasificationId, b.clasificationId, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
