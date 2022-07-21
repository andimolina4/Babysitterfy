import { Component, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
/* import * as EventEmitter from 'events'; */
import { ProfileService } from '../profiles/services/profile.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  isBabysitter = false;
  isParent = true;
  selectedFile!: File;
  base64textString = '';
  imagePath!: any;
  imgURL: any;
  genderSelect!:string;
  message!: string;
  formHidden = true;
  
  profile = {
    firstName:'',
    lastName:'',
    image: '',
    gender:'',
    dateOfBirth:'',
    price:'',
    workTime:'',
    phone:'',
    token:'',
  }

  /* @Output() registerClick = new EventEmitter<Profile>(); */
  constructor(private ProfileSvc: ProfileService, private router: Router) { }

  ngOnInit(): void {
  }

  register({value: formData}: NgForm):any{
    const data = {
      ...formData,
      firstName: formData.firstName,
      lastName: formData.lastName,
      dateOfBirth: formData.dateOfBirth,
      phone: formData.phone,
      image: this.base64textString,
      gender: this.genderSelect,
      token: '',
      price:20,
      workTime:'sadsadsdasad'
    }
    
    this.ProfileSvc.postProfile(data).subscribe(data => {
      console.log(data)
    });
    formData.reset();
    /* this.goToProfiles(); */
  }

  goToProfiles():void{
    this.router.navigate(['./profiles']);
  }
  goToBabysitterRegister():void{
    this.router.navigate(['./register/babysitter']);
  }
  goToParentRegister():void{
    this.router.navigate(['./landpage']);
  }
  selectFile(event:any){
    var files = event.target.files;
    var file = files[0];

    if (files && file) {
        var reader = new FileReader();
        this.imagePath = files;
        reader.onload = (event:any) =>{
          this.imgURL = event.target.result;
          this.handleFile.bind(this);
        }
        reader.readAsDataURL(event.target.files[0]);
    } 
  }

  handleFile(event:any) {
    var binaryString = event.target.result;
          this.base64textString= btoa(binaryString);
          console.log(btoa(binaryString));
  }

  gender(event:any):string{
    return this.genderSelect = event;
  }

}

/* IGNORAR TODA ESTA LOGICA LO UNICO QUE SIRVEN SON LOS NAVIGATE HACIA LOS RESPECTIVOS REGISTER*/