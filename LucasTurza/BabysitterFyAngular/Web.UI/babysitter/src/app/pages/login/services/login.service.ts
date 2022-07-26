import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Login } from "../interfaces/login.interface";

@Injectable({
    providedIn: 'root'
})

export class LoginService {
    /* Service encargado del POST register de l@s babysitter*/
    constructor (private http: HttpClient){}
    private apiURL = 'https://localhost:7106/api';

    postProfile(login: Login): Observable<any>{
        const headers = {'Content-Type':'application/json'}
        const body = JSON.stringify(login);
        console.log(body);
        return this.http.post(this.apiURL + "/Account/login",body,{'headers':headers});
    }

}