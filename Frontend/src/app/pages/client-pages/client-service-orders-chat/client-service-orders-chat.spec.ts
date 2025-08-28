import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientServiceOrdersChat } from './client-service-orders-chat';

describe('ClientServiceOrdersChat', () => {
  let component: ClientServiceOrdersChat;
  let fixture: ComponentFixture<ClientServiceOrdersChat>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientServiceOrdersChat]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientServiceOrdersChat);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
