import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ContractsService } from '../../services/contracts.service';
import { IClient } from '../../interfaces/client';
import { ClientsService } from '../../services/clients.service';
import { IUser } from '../../interfaces/user';
import { UsersService } from '../../services/users.service';
import { IContract } from '../../interfaces/contract';
import { NotificationUiService } from '../../services/notification-ui.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {
  formGroup: FormGroup;
  editMode: boolean;
  contractId: string;

  clients: IClient[];
  installers: IUser[];

  constructor(private contractsServices: ContractsService, private formBuilder: FormBuilder, private clientsService: ClientsService, private usersService: UsersService, public notificationService: NotificationUiService, public dialogRef: MatDialogRef<ContractComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {

    this.clientsService.getClientsSelect().subscribe(clients => { this.clients = clients; }, error => console.log(error));
    this.usersService.getInstaladores().subscribe(instaladores => { this.installers = instaladores; }, error => console.log(error));
    

    this.formGroup = this.formBuilder.group({
      id: '',
      clientId: '',
      numero: '',
      suplemento: false,
      numeroSuplement: 0,
      fechaEntrega: '',
      fechaFirma: '',
      fechaRecibido: '',
      idInstalador: null,
      ubicacion: '',
      objeto: '',
      importeLicenciasCUC: 0,
      importeLicenciasMN: 0,
      importePostVentaCUC: 0,
      importePostVentaMN: 0,
      inicioPostVenta: '',
      finalPostVenta: '',
      master: ''
    });

    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.contractId = this.data['contractId'];

      this.contractsServices.getContract(this.contractId).subscribe(contract => { this.loadFrom(contract); }, error => console.log(error));
    }
  }

  loadFrom(contract: IContract) {
    this.formGroup.patchValue({
      id: contract.id,
      clientId: contract.clientId,
      numero: contract.numero,
      suplemento: contract.suplemento,
      numeroSuplement: contract.numeroSuplement,
      fechaEntrega: contract.fechaEntrega,
      fechaFirma: contract.fechaFirma,
      fechaRecibido: contract.fechaRecibido,
      idInstalador: contract.idInstalador,
      ubicacion: contract.ubicacion,
      objeto: contract.objeto,
      importeLicenciasCUC: contract.importeLicenciasCUC,
      importeLicenciasMN: contract.importeLicenciasMN,
      importePostVentaCUC: contract.importePostVentaCUC,
      importePostVentaMN: contract.importePostVentaMN,
      inicioPostVenta: contract.inicioPostVenta,
      finalPostVenta: contract.finalPostVenta,
      master: contract.master
    });
  }

  onSave() {
    let contract: IContract = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      this.contractsServices.updateContract(this.contractId, contract).subscribe(contract => { this.onSaveSuccess(); }, error => console.log(error));
    } else {
      this.contractsServices.createContract(contract).subscribe(contract => { this.onSaveSuccess(); }, error => console.log(error));
    }
  }

  onSaveSuccess(msg: string = 'Operación completada') {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
