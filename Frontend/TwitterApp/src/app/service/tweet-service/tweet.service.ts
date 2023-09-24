import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Tweet } from  '../../model/tweet.model';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})


export class TweetService {
  readonly url = 'http://localhost:5187/api/Tweets/byUserId/1';
   deleteUrl: string = 'http://localhost:5187/api/Tweets?id=';

  constructor(private http: HttpClient) { }

    getAll(): Observable<Tweet[]>{

      return this.http.get<Tweet[]>(this.url);
    }

    delete(id: string){
      let urld= this.deleteUrl + id;
      return this.http.delete(urld);
    }
   }

   

