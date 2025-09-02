import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderLayout } from './header-layout';

describe('Header', () => {
  let component: HeaderLayout;
  let fixture: ComponentFixture<HeaderLayout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HeaderLayout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeaderLayout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
