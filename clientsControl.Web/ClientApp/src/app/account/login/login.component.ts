import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private usersService: UsersService) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      userName: '',
      password: ''
    });
  }

}
