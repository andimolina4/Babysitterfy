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
          console.log("esta logeado");
          this.route.navigate(['./profiles']);
        }else{
          console.log("no esta logeado");
        }
        console.log("cambio de pagina");
    }});
  }
}