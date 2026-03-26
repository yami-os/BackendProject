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
    this.cargar();
  }

  cargar(): void {
    this.service.getAll().subscribe((data: any) => {
      this.admins = data;
    });
  }

  guardar(): void {
    if (this.editando) {
      this.service.update(this.admin).subscribe(() => {
        this.cargar();
        this.limpiar();
      });
    } else {
      this.service.insert(this.admin).subscribe(() => {
        this.cargar();
        this.limpiar();
      });
    }
  }

  editar(seleccionado: AdministradorModel): void {
    this.editando = true;
    this.admin = { ...seleccionado };
  }

  eliminar(id: number): void {
    if (confirm('¿Estás seguro de eliminar este registro?')) {
      this.service.delete(id).subscribe(() => {
        this.cargar();
      });
    }
  }

  limpiar(): void {
    this.editando = false;
    this.admin = { adm_Id: 0, adm_Nombre: '', adm_Correo: '', adm_Contra: '' };
  }
}