import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  $id!: number;

  saveId(id:number){
    this.$id = id;
  }

  getId():number{
    return this.$id;
  }
}

/* Este es un service que me invente yo para poder ir al perfil del cual diste click en VIEW PROFILE, debe haber otra forma de hacer la cual no se cual es jiji*/