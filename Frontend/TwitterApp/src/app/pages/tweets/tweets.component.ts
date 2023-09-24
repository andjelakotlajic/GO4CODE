import { Component, OnInit,ElementRef, Renderer2, ViewChild  } from '@angular/core';
import { Tweet } from '../../model/tweet.model';
import { TweetService } from 'src/app/service/tweet-service/tweet.service';
import { Observable, Subscription } from 'rxjs';
import { map, filter, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-tweets',
  templateUrl: './tweets.component.html',
  styleUrls: ['./tweets.component.css']
})
export class TweetsComponent implements OnInit {
  tweets: Tweet[] = [];
  tweetUser: string = "Tweet creator";
  tweetcontext: string = "Sadrzaj tvita";
  selectedTweetId: number | null = null;


  constructor(private tweetService: TweetService,private createForm: MatDialog,private renderer: Renderer2){}
  
  ngOnInit() {
    this.getAllTweets();
  }
  getAllTweets() {
    this.tweetService.getAll().subscribe((responseData: Tweet[]) => {
      console.log(responseData);
      this.tweets = responseData;
    });
  }
  showDeleteConfirmation = false;

  openDeleteConfirmation(tweetId: number): void {
    this.selectedTweetId = tweetId;
  }

  confirmDelete(): void {
    if (this.selectedTweetId !== null) {
      this.tweetService.delete(this.selectedTweetId.toString()).subscribe();
      this.getAllTweets();
      this.selectedTweetId = null; 
    }
  }

  cancelDelete(): void {
    this.selectedTweetId = null;
  }

  createTweetData: { content: string } = { content: '' };
  isCreateTweetPopupVisible = false;

  openCreateTweetPopup(): void {
    this.isCreateTweetPopupVisible = true;
  }

  closeCreateTweetPopup(): void {
    this.isCreateTweetPopupVisible = false;
    this.createTweetData.content = ''; 
  }
 createTweet(){
    this.tweetService.create(this.createTweetData.content).subscribe(
      (response) => {
        console.log('Tweet uspešno kreiran:', response);
        this.closeCreateTweetPopup();
        this.getAllTweets();
      },
      (error) => {
        console.error('Greška prilikom kreiranja tvita:', error);
      }
    );
 }

}

