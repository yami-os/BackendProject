import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.css'] 

})
export class NavbarComponent implements OnInit {

  usuario: any = null;

  ngOnInit(): void {
    const user = localStorage.getItem('usuario');
    this.usuario = user ? JSON.parse(user) : null;
  }

  logout() {
    localStorage.removeItem('usuario');
    this.usuario = null;
    window.location.href = '/login';
  }
}