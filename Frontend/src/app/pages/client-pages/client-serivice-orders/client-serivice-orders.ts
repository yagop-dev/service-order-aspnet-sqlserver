import { Component } from '@angular/core';

@Component({
  selector: 'app-client-serivice-orders',
  imports: [],
  templateUrl: './client-serivice-orders.html',
  styleUrl: './client-serivice-orders.css'
})
export class ClientSeriviceOrders {
  orderName = "Limpeza e manutenção preventiva de notebook"
  orderDescription = this.orderName + "\nSubstituição de HD por SSD de 480GB em notebook Dell Inspiron."
}
