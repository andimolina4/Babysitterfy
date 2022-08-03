import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { ProfilesComponent } from './pages/profiles/profiles.component';
import { MdbModule } from './mdb.module';
import { MaterialModule } from './material.module';
import { RegisterComponent } from './pages/register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './pages/profiles/profile/profile.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { BabysitterRegisterComponent } from './pages/register/babysitter-register/babysitter-register.component';
import { ParentRegisterComponent } from './pages/register/parent-register/parent-register.component';
import { AngularFireModule } from "@angular/fire/compat";
import { AngularFireStorageModule } from '@angular/fire/compat/storage'
import { LoginComponent } from './pages/login/login.component';
import { ContractComponent } from './pages/contract/contract.component';
import { ShowallComponent } from './pages/showall/showall.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProfilesComponent,
    RegisterComponent,
    ProfileComponent,
    FooterComponent,
    BabysitterRegisterComponent,
    ParentRegisterComponent,
    LoginComponent,
    ContractComponent,
    ShowallComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,     
    MdbModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    AngularFireModule.initializeApp({
      apiKey: "AIzaSyD-VjTM4WZ4nLRbkPov0HEiWq8srlHSin4",
      authDomain: "babysitterfy-88f29.firebaseapp.com",
      projectId: "babysitterfy-88f29",
      storageBucket: "babysitterfy-88f29.appspot.com",
      messagingSenderId: "335647103175",
      appId: "1:335647103175:web:865290ed3de455517a86e2",
      measurementId: "G-JMPGZ5BPRK"
    }),
    AngularFireStorageModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
