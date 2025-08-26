import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-client-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './client-login.html',
  styleUrls: ['./client-login.css']
})


export class ClientLogin {
  email = '';
  errorMsg = '';

  constructor(private router: Router, private auth: AuthService){}


  back(){
    this.router.navigate(['']);
  }

  register(){
    this.router.navigate(['client-register'])
  }

  enter(){
    this.errorMsg = '';
    if(!this.email){
      this.errorMsg = 'E-mail required.';
      return;
    }
    this.auth.login(this.email).subscribe({
      next: (client) => {
        this.router.navigate(['client-profile', client.id]);
      },
      error: (err) =>{
        this.errorMsg = err.status === 401 ? 'E-mail not found.' : 'Login error.';
        console.error(err);
      }
    });
  }
}
