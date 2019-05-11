import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportPlanificationComponent } from './support-planification.component';

describe('SupportPlanificationComponent', () => {
  let component: SupportPlanificationComponent;
  let fixture: ComponentFixture<SupportPlanificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportPlanificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportPlanificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
