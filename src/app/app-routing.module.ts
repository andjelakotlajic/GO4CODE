import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './pages/register/register.component';
import { TweetsComponent } from './pages/tweets/tweets.component';

const routes: Routes = [
  {path:'register',component:RegisterComponent},
  {path: 'tweet',component:TweetsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
