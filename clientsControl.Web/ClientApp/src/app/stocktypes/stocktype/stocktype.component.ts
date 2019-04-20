import { Component, OnInit, Inject } from '@angular/core';
import { StocktypesService } from '../../services/stocktypes.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NotificationUiService } from '../../services/notification-ui.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IStocktypes } from '../../interfaces/stocktypes';

@Component({
  selector: 'app-stocktype',
  templateUrl: './stocktype.component.html',
  styleUrls: ['./stocktype.component.css']
})
export class StocktypeComponent implements OnInit {
  editMode: boolean;
  stockTypeId: string;
  formGroup: FormGroup;
  ignorePendingChanges: boolean = true;

  constructor(private stockTypesService: StocktypesService, private formBuilder: FormBuilder, public notificationService: NotificationUiService, public dialogRef: MatDialogRef<StocktypeComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      id: '',
      description: '',
      workStations: 0
    });

    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.stockTypeId = this.data['stockTypeId'];
      this.stockTypesService.getStockType(this.stockTypeId).subscribe(stockType => { this.loadForm(stockType); }, error => console.log(error));
    }
  }

  loadForm(module: IStocktypes) {
    this.formGroup.patchValue({
      id: module.id,
      description: module.description,
      workStations: module.workStations
    });
  }

  onSave() {
    let stockType: IStocktypes = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      this.stockTypesService.updateStockType(this.stockTypeId, stockType).subscribe(stockType => { this.onSuccessSave(); }, error => console.log(error));
    } else {
      this.stockTypesService.createStockType(stockType).subscribe(stockType => { this.onSuccessSave(); }, error => console.log(error));
    }
  }

  onSuccessSave(msg: string = "Operación completada") {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
