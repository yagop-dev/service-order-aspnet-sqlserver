import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { Client } from "../models/client.model";

@Injectable({
    providedIn: 'root'
})

export class AuthService{
    private apiUrl = 'https://localhost:7034/api/auth'

    constructor(private http: HttpClient){}

    register(name:string, telephone:string, email:string): Observable<Client>{
        return this.http.post<Client>(`${this.apiUrl}/register`,{name,telephone,email})
    }

    //#region login

    login(email: string): Observable<Client>{
        return this.http.post<Client>(`${this.apiUrl}/login`,{email}).pipe(
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
}