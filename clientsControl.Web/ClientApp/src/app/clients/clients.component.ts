import { Component, OnInit } from '@angular/core';
import { IClient } from '../interfaces/client';
import { ClientsService } from '../services/clients.service';


@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  //clients: IClient[];

  constructor(private clientService: ClientsService) {
    
  }

  ngOnInit() {
    //this.loadData();
  }

  //loadData() {
  //  this.clientService.getClients()
  //    .subscribe(clientsFromWebService => this.clients = clientsFromWebService, error => console.log(error));
  //}

}
