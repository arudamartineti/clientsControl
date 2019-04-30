import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IUser } from '../../interfaces/user';
import { UsersService } from '../../services/users.service';
import { RolesService } from '../../services/roles.service';
import { IRole } from '../../interfaces/role';
import { IUserRole } from '../../interfaces/user-role';
import { NotificationUiService } from '../../services/notification-ui.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  formGroup: FormGroup;
  userId: string;
  user: IUser;
  roles: IRole[];
  editMode: boolean;

  constructor(public notificationService: NotificationUiService, private formBuilder: FormBuilder, public dialogRef: MatDialogRef<UserComponent>, @Inject(MAT_DIALOG_DATA) public data: any, private userService: UsersService, private roleServices: RolesService) { }

  ngOnInit() {        
    if (this.data != null && this.data['editMode'] == true) {
      this.editMode = true;
      this.userId = this.data['userId'];

      this.formGroup = this.formBuilder.group({
        id: this.userId,
        roles: new FormArray([])

      });

      this.userService.getUser(this.userId).subscribe(
        user => {
          this.user = user;

          this.roleServices.getRoles().subscribe(roles => {
            this.roles = roles;
            roles.map((r, i) => {              
              const control = new FormControl(((this.user.roles != undefined && this.user.roles != [] && this.user.roles.indexOf(r.name) > -1)));
              (this.formGroup.controls.roles as FormArray).push(control);
            });
          }, error => console.log(error));
        }, error => console.log(error));                  
    }      
  }

  onSave() {
    const userRole: IUserRole = { id: this.userId, roles : [] };   
    for (let i = 0; i < this.roles.length; i++)
      if ((this.formGroup.controls.roles as FormArray).controls[i].value == true)
        userRole.roles.push(this.roles[i].name);

    this.userService.setUserRoles(this.userId, userRole).subscribe(result => {
      this.onSaveSuccess();
    }, error => console.log(error));
    console.log(userRole);
  }

  onSaveSuccess(msg: string = "Operación completada") {
    this.dialogRef.close();
    this.notificationService.success(msg);
  }

}
