import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConvocatoriaModel } from '../models/convocatoria';

@Injectable({
  providedIn: 'root'
})
export class ConvocatoriaService {

  private url = 'https://localhost:7282/api/Convocatoria';

  constructor(private http: HttpClient) {}

 getAll(): Observable<ConvocatoriaModel[]> {
  return this.http.get<ConvocatoriaModel[]>(this.url);
}

  insert(data: any) {
    return this.http.post(this.url, data);
  }

 
update(id: number, data: ConvocatoriaModel) {
  return this.http.put(`${this.url}/${id}`, data);
}

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}