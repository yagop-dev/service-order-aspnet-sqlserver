import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Technician } from "../models/technician.model";

@Injectable({
  providedIn: 'root'
})

export class TechnicianService{
    private apiUrl = 'https://localhost:7034/api/techinicians';
}