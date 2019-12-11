import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../services/accounts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private accountsService: AccountsService, private router: Router) { }

  ngOnInit() {
  }

  isLogued() {
    return this.accountsService.isLogued();
  }

  logout() {
    this.accountsService.logoutUser();
    this.router.navigate(['/']);
  }

}
