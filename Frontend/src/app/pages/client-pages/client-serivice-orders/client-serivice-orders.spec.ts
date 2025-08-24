import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientSeriviceOrders } from './client-serivice-orders';

describe('ClientSeriviceOrders', () => {
  let component: ClientSeriviceOrders;
  let fixture: ComponentFixture<ClientSeriviceOrders>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientSeriviceOrders]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientSeriviceOrders);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
