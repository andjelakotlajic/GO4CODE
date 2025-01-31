import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import {MatFormFieldModule} from '@angular/material/form-field';
import { NavbarComponent } from './navbar/navbar.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';



import { TweetsComponent } from './pages/tweets/tweets.component';
import { AppComponent } from './app.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthInterceptorService } from './service/register-service/register-interceptor.service';
import { AuthGuard } from '../../src/app/service/register-service/auth-guard.service';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';

 const routes: Routes = [
  {path:'',redirectTo:'register',pathMatch:'full'},
  {path:'register',component:RegisterComponent},
  {path: 'tweet',component:TweetsComponent,canActivate: [AuthGuard]},
  {path: 'userProfile',component:UserProfileComponent,canActivate: [AuthGuard]}
];

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    NavbarComponent,
    TweetsComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatCardModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    MatDialogModule
    
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },AuthGuard

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
