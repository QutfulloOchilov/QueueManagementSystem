import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationComponent } from './pages/authorization/authorization.component';
import { RegistrationComponent } from './pages/registration/registration.component';

const routes: Routes = [
  {path: '', redirectTo: '/authorization', pathMatch: 'full'},
  {path: 'authorization', component: AuthorizationComponent, },
  {path: 'registration', component: RegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
