import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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
    AssetsVersionsGridComponent, AssetsVersionComponent, ConfirmationDialogComponent, ModulesComponent, ModulesGridComponent, ModuleComponent         
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
      { path: 'clients', component: ClientsComponent },
      { path: 'assets-versions', component: AssetsVersionsComponent },
      { path: 'modules', component: ModulesComponent },
    ]),
    BrowserAnimationsModule,
    LayoutModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,    
  ],
  providers: [ClientsService, AssetsversionService, ModulesService, NotificationUiService],
  bootstrap: [AppComponent],
  entryComponents: [ClientComponent, AssetsVersionComponent, ModuleComponent, ConfirmationDialogComponent]
})
export class AppModule { }
