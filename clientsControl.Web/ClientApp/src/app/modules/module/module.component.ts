import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { IModule } from '../../interfaces/module';
import { NotificationUiService } from '../../services/notification-ui.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ModulesService } from '../../services/modules.service';

@Component({
  selector: 'app-module',
  templateUrl: './module.component.html',
  styleUrls: ['./module.component.css']
})
export class ModuleComponent implements OnInit {

  editMode: boolean;
  moduleId: string;
  formGroup: FormGroup;
  ignorePendingChanges: boolean = true;

  constructor(private modulesService: ModulesService, private formBuilder: FormBuilder, public notificationService: NotificationUiService, public dialogRef: MatDialogRef<ModuleComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      id: '',
      description: '',
      workStations: 0
    });    

    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.moduleId = this.data['moduleId'];
      this.modulesService.getModule(this.moduleId).subscribe(module => { this.loadForm(module); }, error => console.log(error));
    }
  }

  loadForm(module: IModule) {
    this.formGroup.patchValue({
      id: module.id,
      description: module.description,
      workStations: module.workStations
    });
  }

  onSave() {
    let module: IModule = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      this.modulesService.updateModule(this.moduleId, module).subscribe(module => { this.onSuccessSave(); }, error => console.log(error));
    } else {
      this.modulesService.createModule(module).subscribe(module => { this.onSuccessSave(); }, error => console.log(error));
    }
  }

  onSuccessSave(msg: string = "Operación completada") {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
