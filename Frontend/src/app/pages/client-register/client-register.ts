import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-register',
  standalone: true,
  imports: [],
  templateUrl: './client-register.html',
  styleUrl: './client-register.css'
})

export class ClientRegister {
  constructor(private router: Router){}

  back(){
    this.router.navigate(['']);
  }
}
