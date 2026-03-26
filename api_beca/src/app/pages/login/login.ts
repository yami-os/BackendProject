import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { Router, RouterModule } from '@angular/router';

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

  constructor(private router: Router) {}

  onLogin() {
    console.log('Intentando entrar con:', this.usuario);
    

    if(this.usuario.email !== '' && this.usuario.password !== '') {
      alert('¡Bienvenido al sistema!');
      this.router.navigate(['/']); 
    } else {
      alert('Por favor, llena todos los campos');
    }
  }
}

