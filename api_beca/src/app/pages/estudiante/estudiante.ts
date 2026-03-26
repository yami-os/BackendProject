import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EstudianteService } from '../../services/estudiante.service'
import { EstudianteModel } from '../../models/estudiante';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './estudiante.html',
})
export class EstudianteComponent implements OnInit {

  estudiantes: EstudianteModel[] = [];
  editando = false;

  est: EstudianteModel = {
    est_Id: 0,
    est_Nombre: '',
    est_Correo: '',
    est_Contra: '',
    est_Carrera: '',
    est_Telefono: 0,
    est_Direccion: ''
  };

  constructor(private service: EstudianteService) {}

  ngOnInit(): void {
    this.listar();
  }

  listar(): void {
    this.service.getAll().subscribe((data: any) => {
      this.estudiantes = data;
    });
  }

  guardar(): void {
    if (this.editando) {
      this.service.update(this.est).subscribe(() => {
        this.listar();
        this.limpiar();
      });
    } else {
      this.service.insert(this.est).subscribe(() => {
        this.listar();
        this.limpiar();
      });
    }
  }

  editar(item: EstudianteModel): void {
    this.editando = true;
    this.est = { ...item };
  }

  eliminar(id: number): void {
    if (confirm('¿Eliminar estudiante?')) {
      this.service.delete(id).subscribe(() => this.listar());
    }
  }

  limpiar(): void {
    this.editando = false;
    this.est = { est_Id: 0, est_Nombre: '', est_Correo: '', est_Contra: '', est_Carrera: '', est_Telefono: 0, est_Direccion: '' };
  }
}