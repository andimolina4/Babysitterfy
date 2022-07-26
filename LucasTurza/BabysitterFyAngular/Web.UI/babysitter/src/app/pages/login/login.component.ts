import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  
  constructor(private loginSvc: LoginService) { }

  ngOnInit(): void {
  }

  loginPost({value: formData}: NgForm):any{
    const data = {
      ...formData,
      username: formData.username,
      password: formData.password,
    }
    this.loginSvc.postProfile(data).subscribe(data => {
      console.log(data.token)
    });
  }
}
