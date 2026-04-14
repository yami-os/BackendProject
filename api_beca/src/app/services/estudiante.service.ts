import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EstudianteModel } from '../models/estudiante';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  private url = 'https://localhost:7282/api/Estudiante';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(this.url);
  }

  insert(data: any) {
    return this.http.post(this.url, data);
  }

  update(id: number, data: any) {
    return this.http.put(`${this.url}/${id}`, data);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}