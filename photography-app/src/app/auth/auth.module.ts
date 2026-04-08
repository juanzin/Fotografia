import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { PhographerManagerComponent } from './phographer-manager/phographer-manager.component';
import { UploadPhotoComponent } from './upload-photo/upload-photo.component';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    PhographerManagerComponent,
    UploadPhotoComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
