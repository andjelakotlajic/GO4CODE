import { RegisterService } from 'src/app/service/register-service/register.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'TwitterApp';

  constructor(private regService: RegisterService){}

  ngOnInit(): void {
    this.regService.loginAuto();
  }
}
