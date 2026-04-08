import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { PublicComponent } from './public.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { AboutComponent } from './about/about.component';
import { PhotoRequestsService } from '../../data/photo-requests.service';


@NgModule({
  declarations: [
    PublicComponent,
    HomeComponent,
    ContactComponent,
    AboutComponent
  ],
  providers: [
    PhotoRequestsService
  ],
  imports: [
    CommonModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
