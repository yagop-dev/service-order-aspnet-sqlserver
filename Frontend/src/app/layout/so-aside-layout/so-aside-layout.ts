import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-so-aside-layout',
  imports: [RouterModule],
  templateUrl: './so-aside-layout.html',
  styleUrl: './so-aside-layout.css'
})
export class SoAsideLayout {
  orderName = "Limpeza e manutenção preventiva de notebook"
  orderDescription = this.orderName + "\nSubstituição de HD por SSD de 480GB em notebook Dell Inspiron."
  
  constructor(private router: Router){}

  createOrder(){
    this.router.navigate(['client-orders-create'])
  }

  openOrder(){
    this.router.navigate(['client-orders-chat']);
  }
}
