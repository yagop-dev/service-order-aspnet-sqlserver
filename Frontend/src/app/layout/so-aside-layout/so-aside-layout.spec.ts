import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoAsideLayout } from './so-aside-layout';

describe('SoAsideLayout', () => {
  let component: SoAsideLayout;
  let fixture: ComponentFixture<SoAsideLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SoAsideLayout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SoAsideLayout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
