import { Component, OnInit } from '@angular/core';
import { IClient } from '../interfaces/client';
import { ClientsService } from '../services/clients.service';


@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  constructor(private clientService: ClientsService) {
    
  }

  ngOnInit() {  
  }

}
