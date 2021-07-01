import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorizationComponent } from './pages/authorization/authorization.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { BusinessProfileComponent } from './pages/business-profile/business-profile.component';
import { ManagePricesComponent } from './pages/manage-prices/manage-prices.component';
import { CRUDWorkersComponent } from './pages/crudworkers/crudworkers.component';
import { OptionToAcceptRejectClientsComponent } from './pages/option-to-accept-reject-clients/option-to-accept-reject-clients.component';
import { ListOfFeedbacksComponent } from './pages/list-of-feedbacks/list-of-feedbacks.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  declarations: [
    AppComponent,
    AuthorizationComponent,
    RegistrationComponent,
    NotificationsComponent,
    BusinessProfileComponent,
    ManagePricesComponent,
    CRUDWorkersComponent,
    OptionToAcceptRejectClientsComponent,
    ListOfFeedbacksComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
