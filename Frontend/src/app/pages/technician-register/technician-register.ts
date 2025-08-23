import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-technician-register',
  standalone: true,
  imports: [],
  templateUrl: './technician-register.html',
  styleUrl: './technician-register.css'
})
export class TechnicianRegister {
  constructor(private router: Router){}

  back(){
    this.router.navigate(['']);
  }
}
