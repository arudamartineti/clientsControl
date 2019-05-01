import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UsersService } from '../../services/users.service';
import { IUser } from '../../interfaces/user';
import { AccountsService } from '../../services/accounts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup: FormGroup;
  loginError: string = "";

  constructor(private formBuilder: FormBuilder, private accountService: AccountsService, private router: Router) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      username: '',
      password: ''
    });
  }
  onLogin() {
    let user: IUser = Object.assign({}, this.formGroup.value);
    this.loginError = "";

    this.accountService.loginUser(user).subscribe(token => { this.loginSuccessHandler(token); }, error => { this.loginErrorHandler(error) });
  }

  loginSuccessHandler(token) {
    localStorage.setItem("securityToken", token.token);
    localStorage.setItem("secutiryTokenExpiration", token.expiration);
    this.router.navigate(['']);
  }

  loginErrorHandler(error) {
    console.log(error);
    this.loginError = error.error.error[0];
    console.log(this.loginError);
  }

}
