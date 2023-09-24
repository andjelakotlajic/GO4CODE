import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Tweet } from  '../../model/tweet.model';
import { Observable, catchError, map, switchMap } from 'rxjs';
import { RegisterService } from '../register-service/register.service';

@Injectable({
  providedIn: 'root'
})


export class TweetService {
  readonly baseUrl = 'http://localhost:5187/api';
   deleteUrl: string = 'http://localhost:5187/api/Tweets?id=';
   username: string = '';

  constructor(private http: HttpClient,private regService: RegisterService) { }

  getAll(): Observable<Tweet[]> {
    let username = this.regService.getUsern();
    if (!username) {
      return new Observable<Tweet[]>(observer => {
        observer.error('Korisničko ime nije pronađeno.');
      });
    }

    return this.getUserId(username).pipe(
      switchMap(userId =>{
        console.log('Korisnički ID:', userId);
        let twurl = `${this.baseUrl}/Tweets/byUserId/${userId}`;
        console.log(twurl);
        return this.http.get<Tweet[]>(twurl);})
      
    );
  }

    delete(id: string){
      let urld= this.deleteUrl + id;
      return this.http.delete(urld);
    }

    create(content:string){
      let username = this.regService.getUsern();
    if (!username) {
      return new Observable<Tweet[]>(observer => {
        observer.error('Korisničko ime nije pronađeno.');
      });
    }
    let createurl = `${this.baseUrl}/Tweets`;
    let body = { content, username };
    return this.http.post(createurl,body);

    }
    private getUserId(username: string): Observable<number> {
      const url = `${this.baseUrl}/User/getUserId/${username}`;
      return this.http.get<number>(url);
    }
  
    private getTweetsByUserId(userId: number): Observable<Tweet[]> {
      const url = `${this.baseUrl}/Tweets/byUserId/${userId}`;
      return this.http.get<Tweet[]>(url);
    }

   }

   

