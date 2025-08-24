import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-type-selector',
  standalone: true,
  imports: [],
  templateUrl: './user-type-selector.html',
  styleUrl: './user-type-selector.css'
})

export class UserTypeSelector {
  constructor(private router: Router){}

  selectClient(){
    this.router.navigate(['/client-login']);
  }

  selectTechnician(){
    this.router.navigate(['/technician-register'])
  }

}
