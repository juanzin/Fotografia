import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { PhographerManagerComponent } from './phographer-manager/phographer-manager.component';
import { UploadPhotoComponent } from './upload-photo/upload-photo.component';
import { DeletePhotoComponent } from './delete-photo/delete-photo.component';


@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    PhographerManagerComponent,
    UploadPhotoComponent,
    DeletePhotoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
