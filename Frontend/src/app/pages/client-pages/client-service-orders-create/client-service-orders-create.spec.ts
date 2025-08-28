import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientServiceOrdersCreate } from './client-service-orders-create';

describe('ClientSeriviceOrdersCreate', () => {
  let component: ClientServiceOrdersCreate;
  let fixture: ComponentFixture<ClientServiceOrdersCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientServiceOrdersCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientServiceOrdersCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
