import { Component, OnInit } from '@angular/core';
import { ClientsService } from '../../services/clients.service';
import { LicenseService } from '../../services/license.service';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { IClient } from '../../interfaces/client';
import { ILicense } from '../../interfaces/license';

@Component({
  selector: 'app-payment-client',
  templateUrl: './payment-client.component.html',
  styleUrls: ['./payment-client.component.css']
})
export class PaymentClientComponent implements OnInit {

  formGroup: FormGroup;
  clients: IClient[];
  licenses: ILicense[] = [];

  constructor(private clientService: ClientsService, private licenseService: LicenseService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      clientId: '',
      expirationDate: '',
      sendByEmail: false,
      public: false,
      licensesId: this.formBuilder.array([])
    });

    this.clientService.getClientsSelect().subscribe(clients => { this.clients = clients; }, error => console.log(error));
  }

  onChangeClient(clientId: string) {
    if (clientId != '') {
      this.licenseService.getLicensesClientSelect(clientId).subscribe(licenses => {
        this.licenses = licenses;
      }, error => console.log(error));

      this.licenses.forEach(license => {
        let licensesId = this.formGroup.get('licensesId') as FormArray;

        licensesId.push(this.formBuilder.group({
          id: license.id,
          selected: false
        }));

      });
    }
  }
}
