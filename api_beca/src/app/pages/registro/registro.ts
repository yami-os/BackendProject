import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './registro.html',
  styleUrl: './registro.css'
})
export class RegistroComponent {
  nuevoEstudiante = {
    nombre: '',
    matricula: '',
    carrera: '',
    email: '',
    password: ''
  };

  constructor(private router: Router) {}

  registrar() {
    console.log('Datos enviados a la BD:', this.nuevoEstudiante);
    
    alert('Registro exitoso. Ahora puedes iniciar sesión.');
    this.router.navigate(['/login']);
  }
}