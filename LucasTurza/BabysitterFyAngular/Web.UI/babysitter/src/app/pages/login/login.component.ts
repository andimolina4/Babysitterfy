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
  logSuccess = true;
  errorMessage!: string;
  isLoading = false;

  constructor(private loginSvc: LoginService, private route: Router) { }

  ngOnInit(): void {
  }

  loginPost({value: formData}: NgForm):any{
    this.isLoading = true;
    this.errorMessage = '';
    const data = {
      ...formData,
      username: formData.username,
      password: formData.password,
    }
    this.loginSvc.postProfile(data).subscribe(
      data => {
        this.token = data.token,
        this.loginCredential = JSON.stringify(data),
        setTimeout(() => {
          this.isLoading = false;
          this.loginSvc.saveToken(this.token);
          this.route.navigate(['./profiles']);
      }, 3000);},
      error => {
        this.isLoading = false,
        this.logSuccess = false,
        this.errorMessage = error.error.title
      });
  }
}
