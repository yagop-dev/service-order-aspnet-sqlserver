import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { Client } from "../models/client.model";
import { Technician } from "../models/technician.model";

@Injectable({
    providedIn: 'root'
})

export class AuthService{
    private apiUrl = 'https://localhost:7034/api/auth'

    constructor(private http: HttpClient){}

    //#region client register
    clientRegister(name:string, telephone:string, email:string): Observable<Client>{
        return this.http.post<Client>(`${this.apiUrl}/client-register`,{name,telephone,email})
    }
    //#endregion

    //#region client login

    clientLogin(email: string): Observable<Client>{
        return this.http.post<Client>(`${this.apiUrl}/client-login`,{email}).pipe(
            tap(client => localStorage.setItem('client', JSON.stringify(client)))
        );
    }

    getLoggedClient(): Client | null {
        const raw = localStorage.getItem('client');
        return raw ? JSON.parse(raw) : null;
    }

    logout(){
        localStorage.removeItem('client');
    }

    //#endregion

    technicianRegister(name:string, email:string, registration:number): Observable<Technician>{
        return this.http.post<Technician>(`${this.apiUrl}/technician-register`, {name, email, registration})
    }
    
}