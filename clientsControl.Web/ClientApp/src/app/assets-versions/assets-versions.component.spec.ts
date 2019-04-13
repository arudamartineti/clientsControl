import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetsVersionsComponent } from './assets-versions.component';

describe('AssetsVersionsComponent', () => {
  let component: AssetsVersionsComponent;
  let fixture: ComponentFixture<AssetsVersionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssetsVersionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetsVersionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
