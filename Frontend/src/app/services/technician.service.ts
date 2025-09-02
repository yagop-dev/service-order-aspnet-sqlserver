import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Technician } from "../models/technician.model";

@Injectable({
  providedIn: 'root'
})

export class TechnicianService{
  private apiUrl = 'https://localhost:7034/api/techinicians';

  constructor(private http: HttpClient){}

  getTechnicians(): Observable<Technician[]>{
    return this.http.get<Technician[]>(this.apiUrl);
  }

  getTechnicianId(id: number): Observable<Technician>{
    return this.http.get<Technician>(`${this.apiUrl}/${id}`);
  }

  createTechnician(technician: Technician): Observable<Technician>{
    return this.http.post<Technician>(this.apiUrl, technician);
  }

  updateTechnician(id: number, technician: Technician): Observable<void>{
    return this.http.put<void>(`${this.apiUrl}/${id}`, technician);
  }

  deleteTechnician(id: number): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}