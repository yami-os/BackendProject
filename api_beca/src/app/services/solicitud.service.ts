import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SolicitudModel } from '../models/solicitud';

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {

  private url = 'https://localhost:7282/api/Solicitud';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<SolicitudModel[]>(this.url);
  }

  insert(data: SolicitudModel) {
    return this.http.post(this.url, data);
  }

  update(data: SolicitudModel) {
    return this.http.put(this.url, data);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}