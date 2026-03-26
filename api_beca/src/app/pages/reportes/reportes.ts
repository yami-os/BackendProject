import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {
  
  private url = 'https://localhost:7282/Convocatorias'; 

  constructor(private http: HttpClient) { }

  
  obtenerReportes(): Observable<any[]> {
    return this.http.get<any[]>(this.url);
  }


  insertarBeca(beca: any): Observable<any> {
    return this.http.post(this.url, beca);
  }
}

