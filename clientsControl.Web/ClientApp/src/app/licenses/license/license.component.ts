import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { LicenseService } from '../../services/license.service';
import { ILicense } from '../../interfaces/license';
import { LicensesComponent } from '../licenses.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ClientsService } from '../../services/clients.service';
import { IClient } from '../../interfaces/client';
import { IClientLicenseClasification } from '../../interfaces/client-license-clasification';
import { IAssetsversion } from '../../interfaces/assetsversion';
import { IStocktypes } from '../../interfaces/stocktypes';
import { StocktypesService } from '../../services/stocktypes.service';
import { AssetsversionService } from '../../services/assetsversion.service';
import { ModulesService } from '../../services/modules.service';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-license',
  templateUrl: './license.component.html',
  styleUrls: ['./license.component.css']
})
export class LicenseComponent implements OnInit {

  formGroup: FormGroup;
  editMode: boolean;
  licenseId: string;

  clients: IClient[];
  clientLicenseClasifications: IClientLicenseClasification[];
  assetsVersions: IAssetsversion[];
  stockTypes: IStocktypes[];

  constructor(public notificationService: NotificationUiService, private modulesService : ModulesService, private stockTypeService: StocktypesService, private assetsVersionService: AssetsversionService, private clientService: ClientsService, private formBuilder: FormBuilder, private licenseService: LicenseService, public dialogRef: MatDialogRef<LicensesComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {    

    this.clientService.getClients().subscribe(clients => { this.clients = clients }, error => console.log(error));
    this.stockTypeService.getStockTypes().subscribe(stocktypes => { this.stockTypes = stocktypes }, error => console.log(error));
    this.assetsVersionService.getAssetsVersions().subscribe(aV => { this.assetsVersions = aV }, error => console.log(error));

    this.formGroup = this.formBuilder.group({
      id: '',
      reup: '',
      name: '',
      code: '',
      creationDate: '',      
      clientId: '',
      versionId: '',
      stockTypeId: '',
      clasificationId: '',
      licenseDetails: this.formBuilder.array([])
    });

    
   
    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.licenseId = this.data['licenseId'];
      this.licenseService.getLicense(this.licenseId).subscribe(license => { this.loadForm(license) }, error => console.log(error));
    } else {

      this.modulesService.getModules().subscribe(modules => modules.forEach(module => {

        let licenseDetail = this.formGroup.get('licenseDetails') as FormArray;

        licenseDetail.push(this.formBuilder.group({
          id: '',
          moduleId: module.id,
          licenceId: '',
          licencias: 0,
          pcAdicionales: 0,
          pcConsultas: 0,
          moduleDescription: module.description,
          workStations: module.workStations
        }));

      }), error => console.log(error));
    }
  }

  loadForm(license: ILicense) {

    this.clientService.getClientClasifications(license.clientId).subscribe(clasifications => {
      this.clientLicenseClasifications = clasifications;
    }, error => console.log(error));    

    this.formGroup.patchValue({
      id: license.id,
      reup: license.reup,
      name: license.name,
      code: license.code,
      creationDate: license.creationDate,
      clientId: license.clientId,
      versionId: license.versionId,
      stockTypeId: license.stockTypeId,
      clasificationId: license.clasificationId      
    });
       
    this.modulesService.getModules().subscribe(modules => modules.forEach(module => {

      let licenseDetail = this.formGroup.get('licenseDetails') as FormArray;

      console.log(license);
          
      licenseDetail.push(this.formBuilder.group({
        id: '',
        moduleId: module.id,
        licenceId: license.id,
        licencias: license.licenseDetails.find(x => x.moduleId === module.id).licencias,
        pcAdicionales: license.licenseDetails.find(x => x.moduleId === module.id).pcAdicionales,
        pcConsultas: license.licenseDetails.find(x => x.moduleId === module.id).pcConsultas,
        moduleDescription: module.description,
        workStations: module.workStations
      }));

    }), error => console.log(error));         
  }

  onSave() {
    let license: ILicense = Object.assign({}, this.formGroup.value);

    if (this.editMode == true) {
      this.licenseService.updateLicense(this.licenseId, license).subscribe(license => { this.onSaveSuccess(), error => console.log(error); })
    } else {
      this.licenseService.createLicense(license).subscribe(license => { this.onSaveSuccess() }, error => console.log(error));
    }
  }

  onSaveSuccess(msg : string = "Operación completada") {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

  displayclientFn(client?: IClient): string | undefined {
    return client ? client.description : undefined;
  }

  onChangeClient(clientId: string) {
    if (clientId != '') {
      this.clientService.getClientClasifications(clientId).subscribe(clasifications => {
        this.clientLicenseClasifications = clasifications;
      }, error => console.log(error));
    }    
  }

}
