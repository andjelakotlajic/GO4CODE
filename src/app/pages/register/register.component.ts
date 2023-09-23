import { Component } from '@angular/core';
import { RegisterService } from 'src/app/service/register-service/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  usernameLog: string ='';
  passwordLog: string = '';

  username: string ='';
  password: string = '';
  firstname: string= '';
  lastname: string= '';
  email: string= '';
  bio: string = '';

  isUsernameLogInvalid: boolean = false;
  isPassLogInvalid: boolean = false;

  isUsernameInvalid: boolean = false;
  isFirstnameInvalid: boolean = false;
  isLastnameInvalid: boolean = false;
  isPasswordInvalid: boolean = false;
  isEmailInvalid: boolean = false;

  currentMode: 'Login' | 'Signup' = 'Login';

  invalidCount: number=0;

  setMode(mode: 'Login' | 'Signup') {
    this.currentMode = mode;
  }

  constructor(private regService: RegisterService, private router: Router){}

  onSubmit() {
    console.log(this.currentMode);
    if (this.currentMode === 'Login') {
      if (!this.usernameLog) {
        this.isUsernameLogInvalid = true;
        this.invalidCount++;
      }else{
        this.isUsernameLogInvalid = false;
        this.invalidCount--;
      }
      if(!this.passwordLog) {
        this.isPassLogInvalid = true;
        this.invalidCount++;
      }else{
        this.isPassLogInvalid = false;
        this.invalidCount--;
      }
      if(this.invalidCount<0){
        let user = this.usernameLog;
        let password = this.passwordLog;
        this.regService.login({username: user, password: password}).subscribe({
          next: (data: any) => {
            this.router.navigate(['/tweet']);
          }
        })
      this.usernameLog='';
      this.passwordLog='';
    }this.invalidCount=0;
    } else if (this.currentMode === 'Signup') {
      if(!this.password) {
        this.isPasswordInvalid = true;
        this.invalidCount++;
      }else{
        this.isPasswordInvalid = false;
        this.invalidCount--;
      }
      if(!this.username) {
        this.isUsernameInvalid = true;
        this.invalidCount++;
      }else{
        this.isUsernameInvalid = false;
        this.invalidCount--;
      }
      if(!this.firstname) {
        this.isFirstnameInvalid = true;
        this.invalidCount++;
      }else{
        this.isFirstnameInvalid = false;
        this.invalidCount--;
      }
      if(!this.lastname) {
        this.isLastnameInvalid = true;
        this.invalidCount++;
      }else{
        this.isLastnameInvalid = false;
        this.invalidCount--;
      }
      if(!this.email) {
        this.isEmailInvalid = true;
        this.invalidCount++;
      }else{
        this.isEmailInvalid = false;
        this.invalidCount--;
      }
      if(this.invalidCount==-5){
        this.regService.register({
          username: this.username, password: this.password,  firstname: this.firstname, lastname: this.lastname,email: this.email,
          bio: ''
        }).subscribe({
          next: () => {
          },
          error: () => {
            console.log("meuspesno");
          }
        })
        this.username ='';
         this.password = '';
        this.firstname= '';
      this.lastname= '';
      this.email= '';
      this.bio= '';
      }
    }
  }
}
