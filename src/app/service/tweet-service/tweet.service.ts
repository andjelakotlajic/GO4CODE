import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tweet } from  '../../model/tweet.model';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})


export class TweetService {

  constructor(private http: HttpClient) { }
    fetchTweets() : Observable<Tweet[]> {
      var url = 'http://localhost:5187/api/Tweets/byUserId/1';
  
      return this.http.get<Tweet[]>(url).pipe(
        map(response => {
          return response;
        }),
      );
    }
    createTweet(tweet: Tweet) : Observable<Tweet> {
      var url = 'http://localhost:5187/api/Tweets/byUserId/1';
      var body = tweet;
  
      return this.http.get<Tweet>(url).pipe(
        map(response => {
          return new Tweet(response.userName, response.context);
        })
      )
  
    }
   }

