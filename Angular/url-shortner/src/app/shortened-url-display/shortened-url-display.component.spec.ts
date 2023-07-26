import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortenedUrlDisplayComponent } from './shortened-url-display.component';

describe('ShortenedUrlDisplayComponent', () => {
  let component: ShortenedUrlDisplayComponent;
  let fixture: ComponentFixture<ShortenedUrlDisplayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShortenedUrlDisplayComponent]
    });
    fixture = TestBed.createComponent(ShortenedUrlDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
