import { TestBed } from '@angular/core/testing';

import { NotificationUiService } from './notification-ui.service';

describe('NotificationUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NotificationUiService = TestBed.get(NotificationUiService);
    expect(service).toBeTruthy();
  });
});
