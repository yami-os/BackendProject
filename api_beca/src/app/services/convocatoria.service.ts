import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConvocatoriaModel } from '../models/convocatoria';

@Injectable({
  providedIn: 'root'
})
export class ConvocatoriaService {
  private url = 'https://localhost:7282/api/Convocatoria'; 

  constructor(private http: HttpClient) { }

  getAll(): Observable<ConvocatoriaModel[]> {
    return this.http.get<ConvocatoriaModel[]>(this.url);
  }

  insert(conv: ConvocatoriaModel): Observable<any> {
    return this.http.post(this.url, conv);
  }

  update(conv: ConvocatoriaModel): Observable<any> {
    return this.http.put(`${this.url}/${conv.con_Id}`, conv);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}