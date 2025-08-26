import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnicianRegister } from './technician-register';

describe('TechnicianRegister', () => {
  let component: TechnicianRegister;
  let fixture: ComponentFixture<TechnicianRegister>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TechnicianRegister]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TechnicianRegister);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
