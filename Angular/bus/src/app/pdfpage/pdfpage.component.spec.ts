import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PdfpageComponent } from './pdfpage.component';

describe('PdfpageComponent', () => {
  let component: PdfpageComponent;
  let fixture: ComponentFixture<PdfpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PdfpageComponent]
    });
    fixture = TestBed.createComponent(PdfpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
