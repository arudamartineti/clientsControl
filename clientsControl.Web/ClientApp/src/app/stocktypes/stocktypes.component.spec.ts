import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktypesComponent } from './stocktypes.component';

describe('StocktypesComponent', () => {
  let component: StocktypesComponent;
  let fixture: ComponentFixture<StocktypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
