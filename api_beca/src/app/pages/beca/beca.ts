import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BecaService } from '../../services/beca.service';
import { BecaModel } from '../../models/beca';

@Component({
  selector: 'app-beca',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './beca.html'
})
export class BecaComponent implements OnInit {

  becas: BecaModel[] = [];

  bec: BecaModel = {
    bec_Id: 0,
    bec_Nombreconv: '',
    bec_NombreEst: '',
    bec_CorreoEst: '',
    bec_ContraEst: '',
    bec_CarreraEst: '',
    bec_TelefonoEst: '',
    bec_DireccionEst: ''
  };

  constructor(private service: BecaService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.service.getAll().subscribe((data: any) => {
      this.becas = data;
    });
  }

  insert(): void {
    this.service.insert(this.bec).subscribe(() => {
      this.getAll();
      this.reset();
    });
  }

  edit(beca: BecaModel): void {
    this.bec = { ...beca };
  }

  update(): void {
    this.service.update(this.bec.bec_Id, this.bec).subscribe(() => {
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
    this.bec = {
      bec_Id: 0,
      bec_Nombreconv: '',
      bec_NombreEst: '',
      bec_CorreoEst: '',
      bec_ContraEst: '',
      bec_CarreraEst: '',
      bec_TelefonoEst: '',
      bec_DireccionEst: ''
    };
  }
}