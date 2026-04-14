import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AutenticacionService } from '../../services/autenticacion.service';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './registro.html'
})
export class RegistroComponent {

  registro = {
    nombre: '',
    correo: '',
    contra: ''
  };

  constructor(private auth: AutenticacionService) {}

  registrar() {
    this.auth.register(this.registro).subscribe(() => {
      alert('Registro exitoso');
      window.location.href = '/login';
    });
  }
}