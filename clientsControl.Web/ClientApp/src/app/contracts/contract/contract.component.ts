import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ContractsService } from '../../services/contracts.service';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {

  formGroup: FormGroup;
  editMode: boolean;
  contractId: string;

  constructor(private contractsServices: ContractsService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      id: '',
      clientId: '',
      numero: '',
      suplemento: false,
      numeroSuplement: 0,
      fechaEntrega: '',
      fechaFirma: '',
      fechaRecibido: '',
      idInstalador: '',
      ubicacion: '',
      objeto: '',
      importeLicenciasCUC: 0,
      importeLicenciasMN: 0,
      importePostVentaCUC: 0,
      importePostVentaMN: 0,
      mesInicioPostVenta: 0,
      mesFinalPostVenta: 0,
      anoFinalPostVenta: 0
    });
  }

}
