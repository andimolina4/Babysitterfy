import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { LoginService } from 'src/app/pages/login/services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isLoggedIn!: boolean;
  username!: string;

  constructor(private router: Router, private loginSvc: LoginService) { 
    this.router.events.subscribe((ev) => {
      if (ev instanceof NavigationEnd) { 
        /* Your code goes here on every router change */
        console.log(this.username);
      this.isLoggedIn = this.loginSvc.isLoggedIn();
      if(this.isLoggedIn){
        this.username = this.loginSvc.getUsername();
      }}
    });
  }

  ngOnInit(): void {

  }

  goHome():void{
    this.router.navigate(['./landpage']);
  }
  
  logOut(){
    this.loginSvc.logOut();
    this.username = '';
    this.isLoggedIn = false;
    this.router.navigate(['./landpage']);
  }

}
