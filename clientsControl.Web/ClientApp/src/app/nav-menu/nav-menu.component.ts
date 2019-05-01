import { Component } from '@angular/core';
import { AccountsService } from '../services/accounts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private accountsService: AccountsService, private router: Router) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isLogued() {
    return this.accountsService.isLogued();
  }

  logout() {
    this.accountsService.logoutUser();
    this.router.navigate(['/']);
  }
}
