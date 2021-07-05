import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationComponent } from './pages/authorization/authorization.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { LayoutWorkerProfileComponent } from './shared/layouts/layout-worker-profile/layout-worker-profile.component';

const routes: Routes = [
    {path: '', redirectTo: '/authorization', pathMatch: 'full'},
    {path: 'authorization', component: AuthorizationComponent, },
    {path: 'registration', component: RegistrationComponent},
    {
      path: '', component: LayoutWorkerProfileComponent, children: [
        {path: 'dashboard', component: DashboardComponent}
      ]
    }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
