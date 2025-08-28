import { Component } from '@angular/core';
import { Router, RouterModule} from '@angular/router';

@Component({
  selector: 'app-header-layout',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './header-layout.html',
  styleUrl: './header-layout.css'
})
export class HeaderLayout {
  pagesWithoutHeader = ['user-type','client-login', 'client-register', 'technician-register'];
  showHeader = false;

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
    this.router.navigate(['client-orders-create'])
  }

  logout(){
    localStorage.removeItem("client");
    this.router.navigate([''])
  }

}
