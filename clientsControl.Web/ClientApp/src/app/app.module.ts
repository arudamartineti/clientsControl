import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClientsComponent } from './clients/clients.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module'
import { ClientsService } from './services/clients.service';
import { AssetsversionService } from './services/assetsversion.service';
import { ClientsGridComponent } from './clients/clients-grid/clients-grid.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MenuComponent } from './menu/menu.component';
import { ClientComponent } from './clients/client/client.component';
import { AssetsVersionsComponent } from './assets-versions/assets-versions.component';
import { AssetsVersionsGridComponent } from './assets-versions/assets-versions-grid/assets-versions-grid.component';
import { AssetsVersionComponent } from './assets-versions/assets-version/assets-version.component'
import { NotificationUiService } from './services/notification-ui.service';
import { ConfirmationDialogComponent } from './shared/confirmation-dialog/confirmation-dialog.component';
import { ModulesComponent } from './modules/modules.component';
import { ModulesGridComponent } from './modules/modules-grid/modules-grid.component';
import { MatTableModule, MatPaginatorModule, MatSortModule } from '@angular/material';
import { ModulesService } from './services/modules.service';
import { ModuleComponent } from './modules/module/module.component';
import { StocktypesComponent } from './stocktypes/stocktypes.component';
import { StocktypeComponent } from './stocktypes/stocktype/stocktype.component';
import { StocktypeGridComponent } from './stocktypes/stocktype-grid/stocktype-grid.component';
import { LicensesComponent } from './licenses/licenses.component';
import { LicenseComponent } from './licenses/license/license.component';
import { LicensesGridComponent } from './licenses/licenses-grid/licenses-grid.component';
import { LicenseService } from './services/license.service';
import { PaymentsComponent } from './payments/payments.component';
import { PaymentComponent } from './payments/payment/payment.component';
import { PaymentsGridComponent } from './payments/payments-grid/payments-grid.component';
import { PaymentClientComponent } from './payments/payment-client/payment-client.component';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactComponent } from './contacts/contact/contact.component';
import { ContactsGridComponent } from './contacts/contacts-grid/contacts-grid.component';
import { UsersComponent } from './users/users.component';
import { UsersGridComponent } from './users/users-grid/users-grid.component';
import { UserComponent } from './users/user/user.component';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { UsersService } from './services/users.service';
import { RolesService } from './services/roles.service';
import { ConfigurationComponent } from './configuration/configuration.component';
import { AuthenticationGuardService } from './services/authentication-guard.service';
import { AccountsService } from './services/accounts.service';
import { AuthenticationInterceptorService } from './services/authentication-interceptor.service';
import { HomeService } from './services/home.service';
import { ContractsComponent } from './contracts/contracts.component';
import { ContractComponent } from './contracts/contract/contract.component';
import { ContractsGridComponent } from './contracts/contracts-grid/contracts-grid.component';
import { ContractsService } from './services/contracts.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClientsComponent,
    ClientsGridComponent,
    MenuComponent,
    ClientComponent,    
    AssetsVersionsComponent,    
    AssetsVersionsGridComponent, AssetsVersionComponent, ConfirmationDialogComponent, ModulesComponent, ModulesGridComponent, ModuleComponent, StocktypesComponent, StocktypeComponent, StocktypeGridComponent, LicensesComponent, LicenseComponent, LicensesGridComponent, PaymentsComponent, PaymentComponent, PaymentsGridComponent, PaymentClientComponent, ContactsComponent, ContactComponent, ContactsGridComponent, UsersComponent, UsersGridComponent, UserComponent, RegisterComponent, LoginComponent, ConfigurationComponent, ContractsComponent, ContractComponent, ContractsGridComponent         
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'clients', component: ClientsComponent, canActivate : [AuthenticationGuardService] },
      { path: 'assets-versions', component: AssetsVersionsComponent },
      { path: 'modules', component: ModulesComponent },
      { path: 'stock-types', component: StocktypesComponent },
      { path: 'licenses', component: LicensesComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'contacts', component: ContactsComponent },
      { path: 'users', component: UsersComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'contracts', component: ContractsComponent },
      { path: 'configuration', component: ConfigurationComponent },
    ]),
    BrowserAnimationsModule,
    LayoutModule,
    MatTableModule,
    MatPaginatorModule, 
    MatSortModule,    
  ],
  providers: [ClientsService, AssetsversionService, ModulesService, LicenseService, NotificationUiService, UsersService, RolesService, AuthenticationGuardService, AccountsService, HomeService, ContractsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent],
  entryComponents: [ClientComponent, AssetsVersionComponent, ModuleComponent, StocktypeComponent, LicenseComponent, ConfirmationDialogComponent, PaymentComponent, PaymentClientComponent, ContactComponent, UserComponent, ContractComponent]
})
export class AppModule { }
