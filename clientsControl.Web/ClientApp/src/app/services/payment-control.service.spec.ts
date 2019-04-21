import { TestBed } from '@angular/core/testing';

import { PaymentControlService } from './payment-control.service';

describe('PaymentControlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PaymentControlService = TestBed.get(PaymentControlService);
    expect(service).toBeTruthy();
  });
});
