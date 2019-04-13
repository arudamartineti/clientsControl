import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material'

@Injectable({
  providedIn: 'root'
})
export class NotificationUiService {

  constructor(public snackBar: MatSnackBar) { }

  conf: MatSnackBarConfig = {
    duration: 2500
  };

  success(msg: string = 'Operación completada') {
    this.conf['panelClass'] = ['notification', 'success'];

    this.snackBar.open(msg, '', this.conf);
  }

  error(msg: string = 'Ha ocurrido un error', errorDetail : string = '') {
    this.conf['panelClass'] = ['notification', 'error']

    this.snackBar.open(msg, '', this.conf);
  }
}
