import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EstudianteModel } from '../models/estudiante';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  private url = 'https://localhost:7282/api/Estudiante'; 

  constructor(private http: HttpClient) { }

  getAll(): Observable<EstudianteModel[]> {
    return this.http.get<EstudianteModel[]>(this.url);
  }

  insert(est: EstudianteModel): Observable<any> {
    return this.http.post(this.url, est);
  }

  update(est: EstudianteModel): Observable<any> {
    return this.http.put(`${this.url}/${est.est_Id}`, est);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}