import { TestBed } from '@angular/core/testing';

import { StocktypesService } from './stocktypes.service';

describe('StocktypesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StocktypesService = TestBed.get(StocktypesService);
    expect(service).toBeTruthy();
  });
});
