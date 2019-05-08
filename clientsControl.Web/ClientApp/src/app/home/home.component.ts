import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../services/accounts.service';
import { ILicenseStatics } from '../interfaces/license-statics';
import { HomeService } from '../services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  statics: ILicenseStatics;
  logued: boolean;

  constructor(private accountsService: AccountsService, private homeService : HomeService) { }

  ngOnInit() {
    this.logued = this.accountsService.isLogued();
    this.homeService.getStatics().subscribe(statics => { this.statics = statics; }, error => console.log(error));
  }
}
