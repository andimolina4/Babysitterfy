import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login = {
    username: '',
    password:'',
  }
  loginCredential: any;
  token!: string;
  constructor(private loginSvc: LoginService, private route: Router) { }

  ngOnInit(): void {
  }

  loginPost({value: formData}: NgForm):any{
    const data = {
      ...formData,
      username: formData.username,
      password: formData.password,
    }
    this.loginSvc.postProfile(data).subscribe(
      data => {
      console.log(data.token)
      this.token = data.token;
      this.loginCredential = JSON.stringify(data);
      setTimeout(() => {
        this.loginSvc.saveToken(this.token);
        this.route.navigate(['./profiles']);
      }, 3000);},
      error => {console.log("jaja le erraste", error)}
      );
  }
}
