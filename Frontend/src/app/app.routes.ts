import { Routes } from '@angular/router';
import { UserTypeSelector } from './pages/user-type-selector/user-type-selector';
import { TechnicianRegister } from './pages/technician-register/technician-register';
import { ClientLogin } from './pages/client-pages/client-login/client-login';
import { ClientRegister } from './pages/client-pages/client-register/client-register';
import { ClientProfile } from './pages/client-pages/client-profile/client-profile';
import { ClientSeriviceOrders } from './pages/client-pages/client-serivice-orders/client-serivice-orders';

export const routes: Routes = [
    {path:'', redirectTo: 'user-type', pathMatch: 'full'},
    {path:'user-type', component: UserTypeSelector},
    {path:'client-login', component: ClientLogin},
    {path:'client-register', component: ClientRegister},
    {path:'client-profile/:id', component: ClientProfile},
    {path:'client-service-orders',component: ClientSeriviceOrders},
    {path:'technician-register', component: TechnicianRegister}
];
