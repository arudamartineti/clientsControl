import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { IClient } from '../../interfaces/client';
import { ILicense } from '../../interfaces/license';
import { ClientsService } from '../../services/clients.service';
import { LicenseService } from '../../services/license.service';
import { ContactsComponent } from '../contacts.component';
import { NotificationUiService } from '../../services/notification-ui.service';
import { ContactsService } from '../../services/contacts.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { IContact } from '../../interfaces/contact';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  formGroup: FormGroup;
  contactId: string;
  editMode: boolean;

  clients: IClient[] = [];
  licenses: ILicense[] = [];

  constructor(private formBuilder: FormBuilder, public notificationService: NotificationUiService, private clientsService: ClientsService, private licenseService: LicenseService, private contactService: ContactsService, public dialogRef: MatDialogRef<ContactsComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.loadClients();

    this.formGroup = this.formBuilder.group({
      id: '',
      name: '',
      email: '',
      phoneNumber: '',
      clientId: '',
      recibeLicencias: '',
      licenseId: ''
    });

    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.contactId = this.data['contactId'];

      this.contactService.getContact(this.contactId).subscribe(contact => { this.loadFrom(contact); }, error => console.log(error));
    }
  }

  loadFrom(contact: IContact) {
    this.formGroup.patchValue({
      id: contact.id,
      name: contact.name,
      email: contact.email,
      phoneNumber: contact.phoneNumber,
      clientId: contact.clientId,
      recibeLicencias: contact.recibeLicencias,
      licenseId: contact.licenseId
    });
  }

  loadClients() {
    this.clientsService.getClientsSelect().subscribe(clients => { this.clients = clients; }, error => console.log(error));
  }

  loadLicenses(clientId : string) {
    if (clientId != '') {      
      this.licenseService.getLicensesClientSelect(clientId).subscribe(licenses => { this.licenses = licenses }, error => console.log(error));
    }
  }

  onSave() {
    let contact: IContact = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      this.contactService.updateContact(this.contactId, contact).subscribe(contact => { this.onSaveSuccess(); }, error => console.log(error));
    } else {
      this.contactService.createContact(contact).subscribe(contact => { this.onSaveSuccess(); }, error => console.log(error));
    }

  }

  onSaveSuccess(msg: string = 'Operación completada') {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
