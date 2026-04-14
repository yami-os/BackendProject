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

  conv: ConvocatoriaModel = {
    con_Id: 0,
    con_Tipo: '',
    con_Fecha: ''
  };

  constructor(private service: ConvocatoriaService) {}

  ngOnInit(): void {
    this.getAll();
  }


  getAll(): void {
   this.service.getAll().subscribe((data: any) =>
    {
      this.convocatorias = data;
    });
  }

  insert(): void {
    this.service.insert(this.conv).subscribe(() =>
    {
      this.getAll();
      this.reset();
    });
  }

  edit(convocatoria: ConvocatoriaModel): void
   {
    this.conv = { ...convocatoria };
    if (this.conv.con_Fecha) {
      this.conv.con_Fecha = this.conv.con_Fecha.split('T')[0];
    }
  }


  update(): void {
    this.service.update(this.conv.con_Id, this.conv).subscribe(() => 
    {
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
    this.conv = {
      con_Id: 0,
      con_Tipo: '',
      con_Fecha: ''
    };
  }
}