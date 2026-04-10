import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AdministradorService } from '../../services/administrador.service';
import { AdministradorModel } from '../../models/administrador';

@Component({
  selector: 'app-administrador',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './administrador.html',
  styleUrl: './administrador.css'
})
export class AdministradorComponent implements OnInit {

  admins: AdministradorModel[] = [];

  admin: AdministradorModel = {
    adm_Id: 0,
    adm_Nombre: '',
    adm_Correo: '',
    adm_Contra: ''
  };

  editando = false;

  constructor(private service: AdministradorService) {}

  ngOnInit(): void {
    this.getAll();
  }

  // 🔥 OBTENER TODOS
  getAll(): void {
    this.service.getAll().subscribe(data => {
      this.admins = data; 
    });
  }

  insert(): void {
    this.service.insert(this.admin).subscribe(() => {
      this.getAll();
      this.reset();
    });
  }

  edit(a: AdministradorModel): void {
    this.admin = { ...a };
    this.editando = true;
  }

  update(): void {
    this.service.update(this.admin).subscribe(() => {
      this.getAll();
      this.reset();
    });
  }

  delete(id: number): void {
    this.service.delete(id).subscribe(() => {
      this.getAll();
    });
  }

  reset(): void {
    this.admin = {
      adm_Id: 0,
      adm_Nombre: '',
      adm_Correo: '',
      adm_Contra: ''
    };
    this.editando = false;
  }
}