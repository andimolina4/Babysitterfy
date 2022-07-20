import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profiles/profile/profile.component';
import { ProfilesComponent } from './pages/profiles/profiles.component';
import { BabysitterRegisterComponent } from './pages/register/babysitter-register/babysitter-register.component';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  {path: '', redirectTo: '/landpage', pathMatch:'full'},
  {path: 'landpage', component: HomeComponent},
  {path: 'register/babysitter', component: BabysitterRegisterComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'profiles', component: ProfilesComponent},
  {path: 'profile', component: ProfileComponent, data: {name:'id'}},
  {path: '**', redirectTo: 'landpage'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
