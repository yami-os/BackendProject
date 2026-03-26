import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BecaModel } from '../models/beca'; 

@Injectable({
  providedIn: 'root'
})
export class ReporteService {
  
  
  private url = 'https://localhost:7282/api/Beca'; 

  constructor(private http: HttpClient) { }


  obtenerReportes(): Observable<any[]> {
    return this.http.get<any[]>(this.url);
  }

  /**
   * Envía una nueva beca a la base de datos
   * @param beca 
   */
  insertarBeca(beca: any): Observable<any> {
    return this.http.post(this.url, beca);
  }
}