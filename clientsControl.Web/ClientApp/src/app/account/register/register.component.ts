import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UsersService } from '../../services/users.service';
import { IUser } from '../../interfaces/user';
import { Router } from '@angular/router';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  formGroup : FormGroup;

  constructor(private formBuider: FormBuilder, private usersServices: UsersService, private notificacionUIService: NotificationUiService,) { }

  ngOnInit() {
    this.formGroup = this.formBuider.group({
      username: '',
      fullName: '',
      phoneNumber: '',
      password: '',
      clientUser: false,
      clientReup: ''
    });
  }

  onSave() {
    let user: IUser = Object.assign({}, this.formGroup.value);

    user.email = user.username;

    this.usersServices.registerUser(user).subscribe(user => {
      this.notificacionUIService.success("El registro se realizó correctamente. Debe esperar confirmación por parte de nuestro personal");      
    }, error => {
      this.notificacionUIService.error("Hubo algún problema al intentar completar su registro");
    });            
  }

}
