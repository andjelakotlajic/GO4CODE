

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, tap } from 'rxjs';
import { User } from '../../model/user.model';


export interface RegResponse {
  token: string, 
  expiration: string
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  rootUrl: string = 'http://localhost:5187/api/Auth/';
  user: BehaviorSubject<User | null> = new BehaviorSubject < User | null > (null);

  constructor(private http: HttpClient) { }

login(data: {username:string,password:string}){
  let loginUrl = this.rootUrl + 'login';
  return this.http.post<RegResponse>(loginUrl,data).pipe(tap((data)=>
{    let user = new User(data.token,data.expiration);
    this.user.next(user);
    localStorage.setItem('user',JSON.stringify(data));
}))
}


register(data: {username:string,password:string,firstname:string,
                lastname:string,email:string,bio:string}){
let regUrl = this.rootUrl + 'register';
return this.http.post<any>(regUrl,data);}
}

