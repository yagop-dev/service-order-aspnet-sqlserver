import { Routes } from '@angular/router';
import { UserTypeSelector } from './pages/user-type-selector/user-type-selector';
import { ClientRegister } from './pages/client-register/client-register';
import { TechnicianRegister } from './pages/technician-register/technician-register';

export const routes: Routes = [
    {path:'', redirectTo: 'user-type', pathMatch: 'full'},
    {path:'user-type', component: UserTypeSelector},
    {path:'client-register', component: ClientRegister},
    {path:'technician-register', component: TechnicianRegister}
];
