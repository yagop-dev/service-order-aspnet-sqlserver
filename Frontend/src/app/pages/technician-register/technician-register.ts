import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-technician-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './technician-register.html',
  styleUrl: './technician-register.css'
})

export class TechnicianRegister implements OnInit {
  registerForm!: FormGroup;

  errorMsg = '';
  successMsg = '';

  ngOnInit(): void{
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      registration: ['', Validators.required]
    })
  }

  constructor(private router: Router, private auth: AuthService, private fb: FormBuilder){}

  back(){
    this.router.navigate(['']);
  }

  onSubmit(){
    this.errorMsg = '';
    this.successMsg = '';

    if(this.registerForm.invalid){
      this.errorMsg = 'Please fill all fields correctly.';
      return;
    }
    
    const {name,email,registration} = this.registerForm.value;

    this.auth.technicianRegister(name!, email!, registration!).subscribe({
      next: (res) =>{
        this.successMsg = `User ${res.name} registered successfully!`;
        this.registerForm.reset();
      },
      error: (err) => {
        if(err.status === 409){
          this.errorMsg = 'Email already registered.';
        }else if(registration < 1000 || registration > 9999){
          this.errorMsg = 'Registration number must be between 1000-9999'
        }else{
          this.errorMsg = 'Registration failed. Try again later.';
        }
      }
    })
  }

}
