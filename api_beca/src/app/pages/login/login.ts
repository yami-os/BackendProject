import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { Router, RouterModule } from '@angular/router';
import { AutenticacionService } from '../../services/autenticacion.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {

  usuario = {
    email: '',
    password: ''
  };

  constructor(private router: Router, private autenticacionService: AutenticacionService) {}

  onLogin() {

    if(this.usuario.email && this.usuario.password) {

      const data = {
        correo: this.usuario.email,
        contra: this.usuario.password
      };

      this.autenticacionService.login(data).subscribe({
        next: (res : any) => {

          alert('Bienvenido ' + res.nombre);

          // guardar sesión
          localStorage.setItem('usuario', JSON.stringify(res));

          // redirección según rol
          if(res.rol === 'administrador'){
            this.router.navigate(['/admin']);
          } else {
            this.router.navigate(['/estudiante']);
          }

        },
        error: () => {
          alert('Correo o contraseña incorrectos');
        }
      });

    } else {
      alert('Llena todos los campos');
    }
  }
}