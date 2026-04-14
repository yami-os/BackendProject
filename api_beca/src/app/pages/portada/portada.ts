import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-portada',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './portada.html',
  styleUrl: './portada.css'
})
export class PortadaComponent {

  becas: any[] = [];
  solicitudes: any[] = [];
  usuario: any = null;

  constructor() {
    this.becas = [
      {
        nombre: 'Beca Académica',
        descripcion: 'Apoyo para estudiantes con buen promedio',
        fechaLimite: new Date()
      }
    ];

    this.solicitudes = [
      {
        becaNombre: 'Beca Académica',
        estado: 'pendiente'
      }
    ];

    this.usuario = {
      correo: 'test@correo.com',
      rol: 'estudiante' 
    };
  }
}