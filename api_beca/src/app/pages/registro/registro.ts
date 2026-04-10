import { Component } from '@angular/core';
import { AutenticacionService } from '../../services/autenticacion.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './registro.html'
})
export class RegistroComponent {

  nuevoRegistro = {
    nombre: '',
    correo: '',
    contra: '',
    rol: 'estudiante'
  };

  constructor(private AutenticacionService: AutenticacionService, private router: Router) {}

  registrar() {
    this.AutenticacionService.register(this.nuevoRegistro).subscribe({
      next: (res) => {
        alert('Registro exitoso');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        alert('Error al registrar o correo ya existe');
        console.log(err);
      }
    });
  }
}