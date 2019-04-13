import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { IClient } from '../../interfaces/client';
import { ClientsService } from '../../services/clients.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material'


@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  formGroup: FormGroup;
  editMode: boolean;
  clientId: string;
  contactsToDelete: string[] = [];
  ignorePendingChanges: boolean = false;

  constructor(private formBuilder: FormBuilder, /*private contactsService: ContactsService, */private clientsServices: ClientsService, private router: Router, private activatedRoute: ActivatedRoute, public dialogRef: MatDialogRef<ClientComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {

  }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      code: '',
      description: ''      
      //contacts: this.formBuilder.array([])
    });
    
    if (this.data != null && this.data['editMode'] == true) {

      this.editMode = true;
      this.clientId = this.data["clientId"];
      this.clientsServices.getClient(this.clientId).subscribe(client => this.loadForm(client), error => this.router.navigate(["/clients"]));

    }

    //this.activatedRoute.params.subscribe(params => {
    //  if (params["id"] == undefined) {
    //    return;
    //  }

    //  this.editMode = true;
    //  this.clientId = params["id"];
    //  this.clientsServices.getClient(this.clientId).subscribe(client => this.loadForm(client), error => this.router.navigate(["/clients"]));

    //});
  }

  pendingChanges(): boolean {
    if (this.ignorePendingChanges == true) { return false; }
    return !this.formGroup.pristine;
  }

  loadForm(client: IClient) {
    this.formGroup.patchValue({
      id: client.id,
      code: client.code,
      description: client.description      
    });

    /*let contacts = this.formGroup.get('contacts') as FormArray;
    client.contacts.forEach(c => {
      let contact = this.buildContact();
      contact.patchValue(c);
      contacts.push(contact);
    });*/

  }

  save() {
    this.ignorePendingChanges = true;

    let client: IClient = Object.assign({}, this.formGroup.value);

    if (this.editMode) {
      client.id = this.clientId;      
      this.clientsServices.updateClient(this.clientId, client).subscribe(client => this.onSaveSuccess(), error => console.log(error));
    }
    else {
      this.clientsServices.createClient(client).subscribe(client => this.onSaveSuccess(), error => console.log(error));
    }

    
  }

  /*deleteContacts() {
    if (this.contactsToDelete.length == 0) {
      this.onSaveSuccess();
      return;
    }

    this.contactsService.deleteContacts(this.contactsToDelete).subscribe(deleted => this.onSaveSuccess(), error => console.log(error));
  }*/

  onSaveSuccess() {
    //this.router.navigate(["/clients"]);
    this.dialogRef.close();
  }

  addContact() {
    let contacts = this.formGroup.get('contacts') as FormArray;
    let contact = this.buildContact();
    contacts.push(contact);
  }

  buildContact() {
    return this.formBuilder.group({
      id: '',
      name: '',
      email: '',
      phoneNumber: '',
      clientId: this.clientId != null ? this.clientId : ''
    });
  }

  removeContact(index: number) {
    let contacts = this.formGroup.get('contacts') as FormArray;
    let contact = contacts.at(index) as FormGroup;

    if (contact.controls["id"] != null) {
      this.contactsToDelete.push(<string>contact.controls["id"].value);
    }

    contacts.removeAt(index);
  }

}
