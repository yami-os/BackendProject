import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SolicitudService } from '../../services/solicitud.service';
import { SolicitudModel } from '../../models/solicitud';

@Component({
  selector: 'app-solicitud',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './solicitud.html',
})
export class SolicitudComponent implements OnInit {

  solicitudes: SolicitudModel[] = [];

  sol: SolicitudModel = {
    sol_Id: 0,
    sol_Fecha: '',
    sol_Estado: '',
    sol_Comentarios: '',
    sol_CorreoEst: '',
    sol_CrearContra: '',
    sol_Telefono: '',
    sol_Direccion: ''
  };

  constructor(private service: SolicitudService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.service.getAll().subscribe((data: any) => {
      this.solicitudes = data;
    });
  }

  insert(): void {
    this.service.insert(this.sol).subscribe(() => {
      this.getAll();
      this.reset();
    });
  }

  edit(solicitud: SolicitudModel): void {
    this.sol = { ...solicitud };

    if (this.sol.sol_Fecha) {
      this.sol.sol_Fecha = this.sol.sol_Fecha.split('T')[0];
    }
  }

  update(): void {
    this.service.update(this.sol.sol_Id, this.sol).subscribe(() => {
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
    this.sol = {
      sol_Id: 0,
      sol_Fecha: '',
      sol_Estado: '',
      sol_Comentarios: '',
      sol_CorreoEst: '',
      sol_CrearContra: '',
      sol_Telefono: '',
      sol_Direccion: ''
    };
  }
}