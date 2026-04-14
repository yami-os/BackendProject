import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConvocatoriaService } from '../../services/convocatoria.service';

@Component({
  selector: 'app-administrador',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './administrador.html'
})
export class AdministradorComponent implements OnInit {

  convocatorias: any[] = [];

  nuevaConvocatoria = {
    con_Id: 0,
    con_Tipo: '',
    con_Fecha: ''
  };

  constructor(private service: ConvocatoriaService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.service.getAll().subscribe((data: any) => {
      this.convocatorias = data;
    });
  }

  agregar() {
    this.service.insert(this.nuevaConvocatoria).subscribe(() => {
      this.getAll();
      this.nuevaConvocatoria = { con_Id: 0, con_Tipo: '', con_Fecha: '' };
    });
  }

  eliminar(id: number) {
    this.service.delete(id).subscribe(() => {
      this.getAll();
    });
  }
}