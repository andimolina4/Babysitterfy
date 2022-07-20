import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BabysitterRegisterService } from './services/babysitter-register.service';
import { AngularFireStorage } from '@angular/fire/compat/storage'
import { url } from 'inspector';
import { stringify } from 'querystring';
import { finalize } from 'rxjs';
import { TimeInterval } from 'rxjs/internal/operators/timeInterval';
@Component({
  selector: 'app-babysitter-register',
  templateUrl: './babysitter-register.component.html',
  styleUrls: ['./babysitter-register.component.scss']
})
export class BabysitterRegisterComponent implements OnInit {
  babysitter = {
    username:'',
    email:'',
    password:'',
    firstname:'',
    lastname:'',
    price:0,
    dateOfBirth:'',
    workTime:'',
    description:'',
    image:'',
    phone:'',
    gender:''
  }
  workDays: string[] = [];
  imageURL!: string;
  pass!: string;
  imgURL!:any;
  confirmPass!: string;
  confirmEquals!: boolean;
  genderSelect!: string;

  constructor(private BabysitterSvc : BabysitterRegisterService, private router: Router, private af:AngularFireStorage) { }

  ngOnInit(): void {
  }

  register({value: formData}: NgForm):any{
    this.passWordEquals(this.pass, this.confirmPass);

    if(this.confirmEquals == true){
      this.uploadImage();

      setTimeout(() => {
        const data = {
          ...formData,
          username: formData.username,
          email: formData.email,
          password: formData.password,
          firstname: formData.firstname,
          lastname: formData.lastname,
          price: formData.price,
          dateOfBirth: formData.dateOfBirth,
          workTime: this.workDays.toString(),
          description: formData.description,
          image: this.imageURL,
          phone: formData.phone,
          gender: this.genderSelect
        }
        console.log(data)
        this.BabysitterSvc.postProfile(data).subscribe(data => {
          console.log(data)
        });
      }, 5000)
      
      /* this.goToProfiles(); */
    }else{
      console.log("somenthing whent wrong");
    }
  }

  path!:string;
  upload($event:any){
    this.path = $event.target.files[0];
    var files = $event.target.files;
    var file = files[0];

    if (files && file) {
        var reader = new FileReader();
        reader.onload = (event:any) =>{
          this.imgURL = event.target.result;
        }
        reader.readAsDataURL($event.target.files[0]);
    } 
  } 
  

  uploadImage(){
    let filePath = `${"/files" + Math.random() + this.path}`
    const fileRef = this.af.ref(filePath);
    this.af.upload(filePath, this.path).snapshotChanges().pipe(
      finalize(() => {
        fileRef.getDownloadURL().subscribe((url) => {
          this.imageURL = url, console.log(this.imageURL);
        })
      })
    ).subscribe();
  }
  
  gender(event:string):string{
    console.log(event);
    return this.genderSelect = event;
  }

  passWordEquals(pass:string, confirmPass:string){
    if(pass == confirmPass){
      this.confirmEquals = true;
    }else{
      this.confirmEquals = false;
    }
  }

  checkPassword(event:any){
    this.pass = event.value;
  }
  checkConfirmPassword(event:any){
    this.confirmPass = event.value;
  }
  
  addDay($event:any){
    console.log($event.source.value);
    console.log($event.source._checked);

    let day:string = $event.source.value;

    console.log(day);

    if($event.source._checked == true){
      this.workDays.push($event.source.value);
    }else{

      this.workDays = this.workDays.filter(x=> x !== day);
    }
    
    console.log(this.workDays.toString());
  }

}
