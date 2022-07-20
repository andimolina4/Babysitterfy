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