import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BenefitsBreakdownComponent } from './benefits-breakdown.component';

describe('BenefitsBreakdownComponent', () => {
  let component: BenefitsBreakdownComponent;
  let fixture: ComponentFixture<BenefitsBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BenefitsBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitsBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
