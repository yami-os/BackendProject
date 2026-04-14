import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {

  private url = 'https://localhost:7282/api/Autenticacion';

  constructor(private http: HttpClient) {}

  login(data: any) {
    return this.http.post(`${this.url}/login`, data);
  }

  register(data: any) {
    return this.http.post(`${this.url}/register`, data);
  }
}