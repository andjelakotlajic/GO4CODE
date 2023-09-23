import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tweet } from  '../../model/tweet.model';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})


export class TweetService {
  readonly url = 'http://localhost:5187/api/Tweets/byUserId/1';

  constructor(private http: HttpClient) { }

    getAll(): Observable<Tweet[]>{

      return this.http.get<Tweet[]>(this.url);
    }
   }

