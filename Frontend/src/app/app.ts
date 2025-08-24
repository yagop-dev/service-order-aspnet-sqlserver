import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, NgModule, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  protected readonly title = signal('Service_Order_Frontend');
  constructor(private router: Router){}

  profile(){
    this.router.navigate(['client-profile'])
  }

  serviceOrder(){
    this.router.navigate(['client-service-orders'])
  }

  logout(){
    this.router.navigate([''])
  }

}
