import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { PhographerManagerComponent } from './phographer-manager/phographer-manager.component';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    PhographerManagerComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
