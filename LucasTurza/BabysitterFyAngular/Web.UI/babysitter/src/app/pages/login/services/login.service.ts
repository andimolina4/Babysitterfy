import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Login } from "../interfaces/login.interface";

@Injectable({
    providedIn: 'root'
})

export class LoginService {

    token!: string;
    loggedIn = false;
    role!: string;
    username!: string;

    /* Service encargado del POST register de l@s babysitter*/
    constructor (private http: HttpClient){}
    private apiURL = 'https://localhost:7106/api';

    postProfile(login: Login): Observable<any>{
        const headers = {'Content-Type':'application/json'}
        const body = JSON.stringify(login);
        console.log(body);
        return this.http.post(this.apiURL + "/Account/login",body,{'headers':headers});
    }

    saveToken(token:string){
        this.token = token;
        localStorage.setItem('currentUser', JSON.stringify(token));
    }
    
    decodeToken(){
        let jwtData = this.token.split('.')[1]
        let decodedJwtJsonData = window.atob(jwtData)
        let decodedJwtData = JSON.parse(decodedJwtJsonData)

        this.role = decodedJwtData.role;
        this.username = decodedJwtData.nameid;

        console.log('jwtData: ' + jwtData)
        console.log('decodedJwtJsonData: ' + decodedJwtJsonData)
        console.log('decodedJwtData: ' + decodedJwtData)
        console.log('Is admin: ' + this.role)
    }

    isLoggedIn():boolean{
        
        if(this.getCurrentUser() != ''){
            this.token = this.getCurrentUser();
            this.loggedIn = true;
            this.decodeToken();
            console.log(this.getCurrentUser())
            console.log(this.token);
        }
        return this.loggedIn;
    }

    getCurrentUser(): string{
        return JSON.parse(localStorage.getItem('currentUser') || '');
    }

    getRole():string{
        return this.role;
    }

    getUsername():string{
        return this.username;
    }

    logOut():void{
        this.loggedIn = false;
        this.token = '';
        this.role = '';
        this.username = '';
        localStorage.setItem('currentUser', JSON.stringify(''));
    }
}