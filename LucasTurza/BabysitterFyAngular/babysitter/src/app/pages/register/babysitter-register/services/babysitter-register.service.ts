import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BabysitterRegister } from "../../interface/babysitter-register.interface";

interface ImageInfo{
    link:string;
  }

@Injectable({
    providedIn: 'root'
})

export class BabysitterRegisterService {
    /* Service encargado del POST register de l@s babysitter*/
    constructor (private http: HttpClient){}
    private apiURL = 'https://localhost:7106/api';

    postProfile(babysitter: BabysitterRegister): Observable<any>{
        const headers = {'Content-Type':'application/json'}
        const body = JSON.stringify(babysitter);
        console.log(body);
        return this.http.post(this.apiURL + "/Account/register",body,{'headers':headers});
    }

}