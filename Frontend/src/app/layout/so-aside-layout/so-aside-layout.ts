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
  orderName = "Notebook cleaning and preventive maintenance"
  orderDescription = this.orderName + "\nReplacing HD with 480GB SSD in Dell Inspiron notebook."
  
  constructor(private router: Router){}

  createOrder(){
    this.router.navigate(['client-orders-create'])
  }

  openOrder(){
    this.router.navigate(['client-orders-chat']);
  }
}
