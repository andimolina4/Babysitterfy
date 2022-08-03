import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BabysitterRegisterService } from './services/babysitter-register.service';
import { AngularFireStorage } from '@angular/fire/compat/storage'
import { finalize } from 'rxjs';

@Component({
  selector: 'app-babysitter-register',
  templateUrl: './babysitter-register.component.html',
  styleUrls: ['./babysitter-register.component.scss']
})
export class BabysitterRegisterComponent implements OnInit {
  /* Componente encargado del register de l@s babysitter */
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
    gender:'',
    province:'',
    address:''
  }

  errorMessage!: string;
  workDays: string[] = [];
  imageURL!: string;
  pass!: string;
  imgURL!:any;
  confirmPass!: string;
  confirmEquals!: boolean;
  genderSelect!: string;
  isLoading = false;

  constructor(private BabysitterSvc : BabysitterRegisterService, private router: Router, private af:AngularFireStorage) { }

  ngOnInit(): void {
  }

  goToLogin(){
    this.router.navigate(['./login'])
  }
  
  /* Manda el POST a la API de l@s babysitter */
  register({value: formData}: NgForm):any{
    this.passWordEquals(this.pass, this.confirmPass);

    if(this.confirmEquals == true){
      this.isLoading = true;

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
        this.BabysitterSvc.postProfile(data).subscribe(
          data => {
            console.log('succes', data),
            this.isLoading = false,
            this.goToLogin()
          },
          error => {
            this.isLoading = false,
            this.errorMessage = error.error.title
          });
      }, 5000)
    }else{
      console.log("somenthing whent wrong");
    }
  }

  /* Logica encargada de mostrar una previsualizacion de la imagen */
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
  
  /* Logica encargada de subir la imagen seleccionada al Storage de Firebase */
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
  
  /* Logica encargada de conseguir el Genero selecionado del FORM para mandarlo en el metodo POST del register de arriba */
  gender(event:string):string{
    console.log(event);
    return this.genderSelect = event;
  }

  /* Logica encargada de comprobar que las contrasñas coincidan, en caso de que no lo hagan no hace el metodo POST del register y tira un error en el FORM */
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
  
  /* Logica encargada de determinar los dias que se checkearon y luego mandarlo en el metodo POST del register */
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

