import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../services/configuration.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { IConfiguration } from '../interfaces/configuration';
import { NotificationUiService } from '../services/notification-ui.service';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {

  formGroup: FormGroup;
  configuration: IConfiguration;

  constructor(public notificationService: NotificationUiService, private configurationService: ConfigurationService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      id: '',
      clientConsecutive: 0,
      licenceConsecutive: 0,
      smtpServer: '',
      smtpPort: 0,
      stmpUser: '',
      smtpPassword: '',
      generatedPaymentControlPath: ''
    });

    this.loadConfiguration();
  }


  loadConfiguration() {
    this.configurationService.getConfiguration().subscribe(configuration => {
      this.formGroup.patchValue({
        id: configuration.id,
        clientConsecutive: configuration.clientConsecutive,
        licenceConsecutive: configuration.licenceConsecutive,
        smtpServer: configuration.smtpServer,
        smtpPort: configuration.smtpPort,
        stmpUser: configuration.stmpUser,
        smtpPassword: configuration.smtpPassword,
        generatedPaymentControlPath: configuration.generatedPaymentControlPath
      });
    }, error => console.log(error));
  }

  saveConfiguration() {
    let configuration: IConfiguration = Object.assign({}, this.formGroup.value);

    this.configurationService.setConfiguration(configuration).subscribe(configuration => {
      this.onSaveSuccess("Configuración salvada correctamente");
    }, error => console.log(error));
  }

  onSaveSuccess(msg : string = "Operación completada") {
    this.notificationService.success(msg);
    this.loadConfiguration();
  }

}
