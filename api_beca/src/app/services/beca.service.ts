import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BecaModel } from '../models/beca';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BecaService {

  private url = 'https://localhost:7282/api/Beca';

  constructor(private http: HttpClient) {}

  getAll(): Observable<BecaModel[]> {
    return this.http.get<BecaModel[]>(this.url);
  }

  insert(data: BecaModel): Observable<any> {
    return this.http.post(this.url, data);
  }

  update(id: number, data: BecaModel): Observable<any> {
    return this.http.put(`${this.url}/${id}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}