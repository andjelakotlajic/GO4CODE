import { Component } from '@angular/core';
import { Tweet } from '../../model/tweet.model';
import { TweetService } from 'src/app/service/tweet-service/tweet.service';
import { Observable, Subscription } from 'rxjs';
import { map, filter, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-tweets',
  templateUrl: './tweets.component.html',
  styleUrls: ['./tweets.component.css']
})
export class TweetsComponent {
  tweets: Tweet[] = [];
  tweetUser: string = "Tweet creator";
  tweetcontext: string = "Sadrzaj tvita";

  constructor(private tweetService: TweetService){}
  
  ngOnInit() {
    var tweetParam = new Tweet(this.tweetUser, this.tweetcontext);

    this.tweetService.createTweet(tweetParam).subscribe({
      next: (data) => {
        console.log(data);
      }
    })
  }

}
