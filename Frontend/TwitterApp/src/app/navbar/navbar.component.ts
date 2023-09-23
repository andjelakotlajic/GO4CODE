import { Component, ElementRef, OnInit} from '@angular/core';
import { Subscription } from 'rxjs';
import { RegisterComponent } from '../pages/register/register.component';
import { Router } from '@angular/router';
import { RegisterService } from '../service/register-service/register.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  searchValue: string = '';
  isAuthenticated: boolean = false;
  userSub: Subscription = new Subscription()
  isMenuOpen: boolean = false; 
  username: string | null = null;
  

  constructor(private regService : RegisterService,private router : Router){}
  

  ngOnInit(): void {
    this.userSub = this.regService.user.subscribe({
      next: (data) => {
        this.isAuthenticated = data ? true : false;
        if (this.isAuthenticated) {
          this.username = this.regService.getUsern();
        }
      }
    })

  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen; 
  }
  logOut(): void  {
   this.regService.logOut();
  }


}
