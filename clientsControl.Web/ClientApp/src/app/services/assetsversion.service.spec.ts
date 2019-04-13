import { TestBed } from '@angular/core/testing';

import { AssetsversionService } from './assetsversion.service';

describe('AssetsversionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AssetsversionService = TestBed.get(AssetsversionService);
    expect(service).toBeTruthy();
  });
});
