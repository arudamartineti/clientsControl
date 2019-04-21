import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { IPaymentControl } from '../../interfaces/payment-control';
import { PaymentControlService } from '../../services/payment-control.service';

export class PaymentsGridDataSource extends DataSource<IPaymentControl> {
  data: IPaymentControl[];

  constructor(private paginator: MatPaginator, private sort: MatSort, private paymentControlService: PaymentControlService) {
    super();
    this.paymentControlService.getPaymentControls().subscribe(payments => { this.data = payments }, error => console.log(error));
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<IPaymentControl[]> {
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
  private getPagedData(data: IPaymentControl[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: IPaymentControl[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'generatedDate': return compare(a.generatedDate, b.generatedDate, isAsc);
        case 'expirationDate': return compare(a.expirationDate, b.expirationDate, isAsc);
        case 'licenceId': return compare(a.licenceId, b.licenceId, isAsc);        
        case 'sentByEmailDate': return compare(a.sentByEmailDate, b.sentByEmailDate, isAsc);
        case 'licenseName': return compare(a.licenseName, b.licenseName, isAsc);
        case 'clientDescription': return compare(a.clientDescription, b.clientDescription, isAsc);
        default: return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
