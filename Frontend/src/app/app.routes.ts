import { Routes } from '@angular/router';
import { UserTypeSelector } from './pages/user-type-selector/user-type-selector';
import { TechnicianRegister } from './pages/technician-register/technician-register';
import { ClientLogin } from './pages/client-pages/client-login/client-login';
import { ClientRegister } from './pages/client-pages/client-register/client-register';
import { ClientProfile } from './pages/client-pages/client-profile/client-profile';
import { ClientServiceOrdersCreate } from './pages/client-pages/client-service-orders-create/client-service-orders-create';
import { HeaderLayout } from './layout/header-layout/header-layout';
import { SoAsideLayout } from './layout/so-aside-layout/so-aside-layout';
import { ClientServiceOrdersChat } from './pages/client-pages/client-service-orders-chat/client-service-orders-chat';

export const routes: Routes = [
    {path:'', redirectTo: 'user-type', pathMatch: 'full'},
    {path:'user-type', component: UserTypeSelector},
    {path:'client-login', component: ClientLogin},
    {path:'client-register', component: ClientRegister},
    {path:'technician-register', component: TechnicianRegister},

    {path: '', component: HeaderLayout,
        children: [
            {path: 'client-profile/:id', component: ClientProfile},
            {path: '', component: SoAsideLayout,
                children: [
                    {path: 'client-orders-create', component: ClientServiceOrdersCreate},
                    {path: 'client-orders-chat', component: ClientServiceOrdersChat}
                ]
            }
        ]
    }
];
