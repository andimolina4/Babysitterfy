import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { LoginService } from './pages/login/services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'babysitter';

  constructor(private loginSvc: LoginService, private route: Router){
    this.route.events.subscribe((ev) => {
      if (ev instanceof NavigationEnd) { 
        /* Your code goes here on every router change */
        if(this.loginSvc.isLoggedIn()){
          if(this.route.url == '/profile'){
            this.route.navigate(['./profile']);
          }else{
            this.route.navigate(['./profiles']);
          }
          if(this.route.url == '/allbabysitters'){
            this.route.navigate(['./allbabysitters']);
          }else{
            this.route.navigate(['./profiles']);
          }
          if(this.route.url == '/contract' && this.loginSvc.getRole() == 'Parent'){
            this.route.navigate(['./contract']);
          }
        }else{
          if(this.route.url == '/profiles'){
            this.route.navigate(['./landpage']);
          }
        }
    }});
  }
}