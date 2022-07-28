import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ParentRegisterService } from '../parent-register/services/parent-register.service'

@Component({
  selector: 'app-parent-register',
  templateUrl: './parent-register.component.html',
  styleUrls: ['./parent-register.component.scss']
})
export class ParentRegisterComponent implements OnInit {
  parent = {
    username: '',
    email: '',
    password: '',
    firstname: '',
    lastname: '',
    dateOfBirth:'',
    phoneNumber: '',
    numberOfChildren: ''
  }
  confirmEquals!: boolean;
  pass: any;
  confirmPass: any;

  constructor(private parentSvc: ParentRegisterService, private router: Router) { }

  ngOnInit(): void {
  }

  goToLogin(){
    this.router.navigate(['./login'])
  }

  register({value: formData}: NgForm):any{
    this.passWordEquals(this.pass, this.confirmPass);

    if(this.confirmEquals == true){

      const data = {
        ...formData,
        username: formData.username,
        email: formData.email,
        password: formData.password,
        firstname: formData.firstname,
        lastname: formData.lastname,
        dateOfBirth: formData.dateOfBirth,
        phoneNumber: formData.phone,
        numberOfChildren: formData.numberOfChildren,
      }
      console.log(data)
      this.parentSvc.postProfile(data).subscribe(
        data => {
        console.log(data),
        this.goToLogin();},
      
        error => console.log("something went wrong", error)
        );
      
    }else{
      console.log("Passwords do not match");
    }
    
  }

  passWordEquals(pass:string, confirmPass:string){
    if(pass == confirmPass){
      this.confirmEquals = true;
    }else{
      this.confirmEquals = false;
    }
  }

  /* Guarda la contraseña del campo Password para luego comprobar si es igual a confirmPassword, (posiblemente esto sea una hermosa falla de seguridad pero equisde) */
  checkPassword(event:any){
    this.pass = event.value;
  }
  /* Lo mismo que arriba pero para el confirmPassword */
  checkConfirmPassword(event:any){
    this.confirmPass = event.value;
  }
  
}
