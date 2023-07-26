import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusselectionComponent } from './busselection.component';

describe('BusselectionComponent', () => {
  let component: BusselectionComponent;
  let fixture: ComponentFixture<BusselectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BusselectionComponent]
    });
    fixture = TestBed.createComponent(BusselectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
