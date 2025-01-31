import { routes } from './../../app-routing.module';


import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, tap } from 'rxjs';
import { User } from '../../model/user.model';
import { Router } from '@angular/router';


export interface RegResponse {
  token: string, 
  expiration: string,
  username:string
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  userName: string ="";
  rootUrl: string = 'http://localhost:5187/api/Auth/';
  user: BehaviorSubject<User | null> = new BehaviorSubject < User | null > (null);
  // isAuthenticated: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient,private router:Router) { }

login(data: {username:string,password:string}){
  let loginUrl = this.rootUrl + 'login';
  let string = this.getUsername(data.username);
  return this.http.post<RegResponse>(loginUrl,data).pipe(tap((data)=>
{    let user = new User(data.token,data.expiration);
    this.user.next(user);
    localStorage.setItem('user',JSON.stringify(data));
    
}))
}
getUsername(username:string): string | null {
  this.userName = username;
    return username;
  }

getUsern(): string | null{
  return this.userName;
  
} 

register(data: {username:string,password:string,firstname:string,
                lastname:string,email:string,bio:string}){
let regUrl = this.rootUrl + 'register';
return this.http.post<any>(regUrl,data);}

loginAuto(){
  let user=localStorage.getItem('user');
  if(user){
    let userJson : User = JSON.parse(user);
    //moze validacija a i ne mora
    this.user.next(userJson);
  }
}


logOut(){
   localStorage.removeItem('user');
    this.user.next(null);
    this.router.navigate(['/register']);
}

}

