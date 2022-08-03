import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Profile } from "../interfaces/profile.interface";

@Injectable({
    providedIn: 'root'
})

export class ProfileService {
    constructor (private http: HttpClient){}
    private apiURL = 'https://localhost:7106/api';

    getProfiles(): Observable<Profile[]>{
        return this.http.get<Profile[]>(this.apiURL+"/Babysitters");
    }

    postProfile(profile: Profile): Observable<any>{
        const headers = {'Content-Type':'application/json'}
        const body = JSON.stringify(profile);
        return this.http.post(this.apiURL + "/Babysitters",body,{'headers':headers});
    }
    
    getProfileById(id:number): Observable<any>{
        return this.http.get<any>(this.apiURL + "/Babysitters/id?id="+ id);
    } 
}

/* esto deberia cambiarse pero funciona por el momento */