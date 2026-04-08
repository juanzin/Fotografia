import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { PhographerManagerComponent } from './phographer-manager/phographer-manager.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'photographerManager', component: PhographerManagerComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
