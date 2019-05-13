import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule, XHRBackend } from '@angular/http';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


/* App Root */
import { MaterialModule } from './material';
import { ProfileComponent } from './profile/profile.component';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatMenuModule, MatDatepickerModule } from '@angular/material';
import { MatNativeDateModule, MatIconModule, MatCardModule } from '@angular/material';
import { MatSidenavModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { MatTooltipModule, MatToolbarModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material/paginator';
/* Account Imports */
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { AccountModule }  from './account/account.module';
/* Dashboard Imports */
import { DashboardModule }  from './dashboard/dashboard.module';

import { ConfigService } from './shared/utils/config.service';
import { from } from 'rxjs';
import { PersonService } from './person.service';
import { AutocompleteFilterComponent } from './autocomplete-filter/autocomplete-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    HeaderComponent,
  ],
  imports: [
    AccountModule,
    DashboardModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatButtonModule,
    HttpModule,
    MatMenuModule,
    MaterialModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatAutocompleteModule,
    MatPaginatorModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'profile', component: ProfileComponent },
    ]),
    AppRoutingModule
  ],
  providers: [
   
    ConfigService, {
      provide: XHRBackend,
      useClass: AuthenticateXHRBackend
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
