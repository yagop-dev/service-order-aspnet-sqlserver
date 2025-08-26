import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './client-register.html',
  styleUrl: './client-register.css'
})

export class ClientRegister implements OnInit{
  registerForm!: FormGroup;

  errorMsg = '';
  successMsg = '';
  
  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      telephone: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
      email: ['', [Validators.required, Validators.email]]
    })
  }
  
  constructor(private router: Router, private auth: AuthService, private fb: FormBuilder){}


  back(){
    this.router.navigate(['client-login']);
  }

  onSubmit(){
    this.errorMsg = '';
    this.successMsg = '';

    if(this.registerForm.invalid){
      this.errorMsg = 'Please fill all fields correctly.';
      return;
    }
    
    const {name,telephone,email} = this.registerForm.value;

    this.auth.register(name!, telephone!, email!).subscribe({
      next: (res) =>{
        this.successMsg = `User ${res.name} registered successfully!`;
        this.registerForm.reset();
      },
      error: (err) => {
        if(err.status === 409){
          this.errorMsg = 'Email already registered.';
        }else{
          this.errorMsg = 'Registration failed. Try again later.';
        }
      }
    })
  }
}
