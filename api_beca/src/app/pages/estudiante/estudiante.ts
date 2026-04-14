import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EstudianteService } from '../../services/estudiante.service';
import { EstudianteModel } from '../../models/estudiante';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './estudiante.html',
})
export class EstudianteComponent implements OnInit {

  estudiantes: EstudianteModel[] = [];

  est: EstudianteModel = {
    est_Id: 0,
    est_Nombre: '',
    est_Correo: '',
    est_Contra: '',
    est_Carrera: '',
    est_Telefono: '',
    est_Direccion: ''
  };

  constructor(private service: EstudianteService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.service.getAll().subscribe((data: any) => {
      this.estudiantes = data;
    });
  }

  insert(): void {
    this.service.insert(this.est).subscribe(() => {
      this.getAll();
      this.reset();
    });
  }

  edit(estudiante: EstudianteModel): void {
    this.est = { ...estudiante };
  }

  update(): void {
    this.service.update(this.est.est_Id, this.est).subscribe(() => {
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
    this.est = {
      est_Id: 0,
      est_Nombre: '',
      est_Correo: '',
      est_Contra: '',
      est_Carrera: '',
      est_Telefono: '',
      est_Direccion: ''
    };
  }

  editando: boolean = false;

limpiar() {
  this.est = {
    est_Id: 0,
    est_Nombre: '',
    est_Correo: '',
    est_Contra: '',
    est_Carrera: '',
    est_Telefono: '',
    est_Direccion: ''
  };
  this.editando = false;
}

guardar() {
  if (this.editando) {
    this.service.update(this.est.est_Id, this.est).subscribe(() => {
      this.getAll();
      this.limpiar();
    });
  } else {
    this.service.insert(this.est).subscribe(() => {
      this.getAll();
      this.limpiar();
    });
  }
}

editar(e: any) {
  this.est = { ...e };
  this.editando = true;
}

eliminar(id: number) {
  this.service.delete(id).subscribe(() => {
    this.getAll();
  });
}
}