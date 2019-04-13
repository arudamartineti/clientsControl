import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AssetsversionService } from '../../services/assetsversion.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AssetsVersionsComponent } from '../assets-versions.component';
import { IAssetsversion } from '../../interfaces/assetsversion';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-assets-version',
  templateUrl: './assets-version.component.html',
  styleUrls: ['./assets-version.component.css']
})
export class AssetsVersionComponent implements OnInit {

  editMode: boolean;
  assetsVersionId: string;
  formGroup: FormGroup;
  ignorePendingChanges: boolean = true;


  constructor(public notificationService: NotificationUiService, private formBuilder: FormBuilder, private assetsVersionService: AssetsversionService, public dialogRef: MatDialogRef<AssetsVersionsComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      id: '',
      description: ''
    });

    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.assetsVersionId = this.data['assetsVersionId'];
      this.assetsVersionService.getAssetsVersion(this.assetsVersionId).subscribe(assetsVersion => { this.loadForm(assetsVersion) }, error => console.log(error));
    }
  }

  loadForm(assetsVersion: IAssetsversion) {
    this.formGroup.patchValue({
      id: assetsVersion.id,      
      description: assetsVersion.description
    });
  }

  onSave() {
    let assetsVersion: IAssetsversion = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      this.assetsVersionService.updateAssetsVersion(this.assetsVersionId, assetsVersion).subscribe(assetsVersion => { this.onSaveSuccess(); }, error => console.log(error));
    } else {
      this.assetsVersionService.createAssetsVersion(assetsVersion).subscribe(assetsVersion => { this.onSaveSuccess(); }, error => console.log(error))
    }
  }

  onSaveSuccess(msg : string = 'Operación completada') {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
