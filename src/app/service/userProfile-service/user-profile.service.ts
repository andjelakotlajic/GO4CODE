import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RegisterService } from '../register-service/register.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserDto } from 'src/app/pages/user-profile/user-profile.component';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  username : string = "";
  private baseUrl = 'http://localhost:5187/api/User/getUserByUsername'; 
  private updateUrl = 'http://localhost:5187/api/User/Update korisnika';

  constructor(private http: HttpClient, private regService: RegisterService) { }


  getUserByUsername(username: string): Observable<any> {
    let userUrl = `${this.baseUrl}/${this.regService.getUsern()}`;
    return this.http.get(userUrl);
  }
  UpdateUser(updatedUser: UserDto): Observable<any> {
    return this.http.put(this.updateUrl, updatedUser);
  }
}
