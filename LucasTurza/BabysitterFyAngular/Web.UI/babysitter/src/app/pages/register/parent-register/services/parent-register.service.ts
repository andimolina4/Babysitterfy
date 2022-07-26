import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ParentRegister } from "../interfaces/parent-register.interface";

@Injectable({
    providedIn: 'root'
})

export class ParentRegisterService {
    /* Service encargado del POST register de l@s babysitter*/
    constructor (private http: HttpClient){}
    private apiURL = 'https://localhost:7106/api';

    postProfile(parent: ParentRegister): Observable<any>{
        const headers = {'Content-Type':'application/json'}
        const body = JSON.stringify(parent);
        console.log(body);
        return this.http.post(this.apiURL + "/Account/parent-register",body,{'headers':headers});
    }

}