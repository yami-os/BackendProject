import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AutenticacionService } from '../../services/autenticacion.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'] 
})
export class LoginComponent {

  loginData = {
    correo: '',
    contra: ''
  };

  constructor(
    private auth: AutenticacionService,
    private router: Router
  ) {}

  login() {
    this.auth.login(this.loginData).subscribe((res: any) => {

   
      localStorage.setItem('usuario', JSON.stringify(res));


      if (res.rol === 'administrador') {
        this.router.navigate(['/admin']);
      } else {
        this.router.navigate(['/portada']);
      }

    }, error => {
      alert('Correo o contraseña incorrectos');
    });
  }
}