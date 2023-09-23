import { RegisterService } from 'src/app/service/register-service/register.service';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './pages/register/register.component';
import { TweetsComponent } from './pages/tweets/tweets.component';
import { AuthGuard } from './service/register-service/auth-guard.service';
import  { UserProfileComponent } from './pages/user-profile/user-profile.component';

//, canActivate([RegisterService])
export const routes: Routes = [
  {path:'',redirectTo:'register',pathMatch:'full'},
  {path:'register',component:RegisterComponent},
  {path: 'tweet',component:TweetsComponent,canActivate: [AuthGuard]},
  {path: 'userProfile',component:UserProfileComponent,canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
