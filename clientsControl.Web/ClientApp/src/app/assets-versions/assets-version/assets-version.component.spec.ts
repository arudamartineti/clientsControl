import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetsVersionComponent } from './assets-version.component';

describe('AssetsVersionComponent', () => {
  let component: AssetsVersionComponent;
  let fixture: ComponentFixture<AssetsVersionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssetsVersionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetsVersionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
