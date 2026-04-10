import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AdministradorModel } from '../models/administrador';

@Injectable({
  providedIn: 'root'
})
export class AdministradorService {
  private url = 'https://localhost:7282/api/Administrador'; 

  constructor(private http: HttpClient) { }

  getAll(): Observable<AdministradorModel[]> {
    return this.http.get<AdministradorModel[]>(this.url);
  }

  insert(admin: AdministradorModel): Observable<any> {
    return this.http.post(this.url, admin);
  }

  update(admin: AdministradorModel): Observable<any> {
    return this.http.put(`${this.url}/${admin.adm_Id}`, admin);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }

  registrarAdmin(data: any) {
  return this.http.post('https://localhost:7282/api/Administrador', data);
}
}