import { Component, OnInit } from '@angular/core';
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
export class TweetsComponent implements OnInit {
  tweets: Tweet[] = [];
  tweetUser: string = "Tweet creator";
  tweetcontext: string = "Sadrzaj tvita";

  constructor(private tweetService: TweetService){}
  
  ngOnInit() {
    this.getAllTweets();
  }
  getAllTweets(){
    setTimeout(()=>{
      this.tweetService.getAll().subscribe((responseData : Tweet[]) =>{
        console.log(responseData);
        this.tweets = responseData;
      });
    },1000)
    
  }
  showDeleteConfirmation = false;

  // ... Ostale metode ...

  // Metoda za otvaranje potvrde brisanja
  openDeleteConfirmation(): void {
    this.showDeleteConfirmation = true;
  }

  // Metoda za potvrdu brisanja
  confirmDelete(): void {
    this.showDeleteConfirmation = false;
    // Ovde možete postaviti logiku za brisanje
  }

  // Metoda za otkazivanje brisanja
  cancelDelete(): void {
    this.showDeleteConfirmation = false;
  }

}
