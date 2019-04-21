import { Component, OnInit, Inject } from '@angular/core';
import { ILicense } from '../../interfaces/license';
import { LicenseService } from '../../services/license.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { IPaymentControl } from '../../interfaces/payment-control';
import { PaymentControlService } from '../../services/payment-control.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  licenses: ILicense[];
  formGroup: FormGroup;

  constructor(private licenseService: LicenseService, private paymentService: PaymentControlService, private formBuilder: FormBuilder, public dialogRef: MatDialogRef<PaymentComponent>, @Inject(MAT_DIALOG_DATA) public data: any, public notificationService: NotificationUiService,) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      licenceId: '',
      expirationDate: '',
      sendByEmail: false,
      public : false
    });

    this.licenseService.getLicensesSelect().subscribe(licenses => { this.licenses = licenses }, error => console.log(error));
  }

  onSave() {
    let payment: IPaymentControl = Object.assign({}, this.formGroup.value);

    this.paymentService.createPaymentControl(payment).subscribe(payment => { this.onSaveSuccess(); }, error => console.log(error));
  }

  onSaveSuccess(msg: string = "Operación completada") {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
