import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConvocatoriaService } from '../../services/convocatoria.service';
import { ConvocatoriaModel } from '../../models/convocatoria';

@Component({
  selector: 'app-convocatoria',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './convocatoria.html',
})
export class ConvocatoriaComponent implements OnInit {
  convocatorias: ConvocatoriaModel[] = [];
  editando = false;
  conv: ConvocatoriaModel = { con_Id: 0, con_Tipo: '', con_Fecha: '' };

  constructor(private service: ConvocatoriaService) {}

  ngOnInit(): void { this.listar(); }

  listar(): void {
    this.service.getAll().subscribe((data: any) => {
      this.convocatorias = data;
    });
  }

  guardar(): void {
    if (this.editando) {
      this.service.update(this.conv).subscribe(() => {
        this.listar();
        this.limpiar();
      });
    } else {
      this.service.insert(this.conv).subscribe(() => {
        this.listar();
        this.limpiar();
      });
    }
  }

  editar(item: ConvocatoriaModel): void {
    this.editando = true;
    this.conv = { ...item };
   
    if (this.conv.con_Fecha) {
      this.conv.con_Fecha = this.conv.con_Fecha.split('T')[0];
    }
  }

  eliminar(id: number): void {
    if (confirm('¿Borrar convocatoria?')) {
      this.service.delete(id).subscribe(() => this.listar());
    }
  }

  limpiar(): void {
    this.editando = false;
    this.conv = { con_Id: 0, con_Tipo: '', con_Fecha: '' };
  }
}