import { Component, signal } from '@angular/core';
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
  pagesWithoutHeader = ['user-type','client-login', 'client-register', 'technician-register'];
  showHeader = false;

  protected readonly title = signal('Service_Order_Frontend');

  constructor(private router: Router){
    this.router.events.subscribe(() =>{
      const currentUrl = this.router.routerState.snapshot.url;
      this.showHeader = !this.pagesWithoutHeader.some(path => currentUrl.startsWith(`/${path}`)) 
    })
  }

  profile(){
    this.router.navigate(['client-profile/:id'])
  }

  serviceOrder(){
    this.router.navigate(['client-service-orders'])
  }

  logout(){
    localStorage.removeItem("client");
    this.router.navigate([''])
  }

}
