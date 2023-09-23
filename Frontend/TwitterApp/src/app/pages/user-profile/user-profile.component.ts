import { Component, OnInit } from '@angular/core';
import { RegisterService } from 'src/app/service/register-service/register.service';
import { UserProfileService } from 'src/app/service/userProfile-service/user-profile.service';

export interface UserDto {
  username: string;
  firstName: string;
  lastName: string;
  bio: string;
}

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})

export class UserProfileComponent implements OnInit {



  username: string = '';
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  bio: string = '';

  isEditMode: boolean = false;

  constructor(private userService: UserProfileService,private regService:RegisterService) {}
  ngOnInit(): void {
    this.getUserDataByUsername(); 
  }

  getUserDataByUsername(): void {
    this.userService.getUserByUsername(this.username).subscribe(
      (data) => {
       this.username = data.username;
       this.firstname = data.firstName;
       this.lastname = data.lastName;
       this.email = data.email;
       this.bio = data.bio;
       console.log(data);
        
      },
      (error) => {
        console.error('Greška pri dohvatanju podataka o korisniku:', error);
      }
    );
    }
    Update(){
      if(!this.isEditMode){

      }else{
        const updatedUser: UserDto = {
          username: this.username,
          firstName: this.firstname,
          lastName: this.lastname,
          bio: this.bio
        };

        this.userService.UpdateUser(updatedUser).subscribe(
          (response) => {
            console.log('Korisnik je uspešno ažuriran.', response);
            this.isEditMode = false; // Izađite iz režima za uređivanje
          },
          (error) => {
            console.error('Greška pri ažuriranju korisnika:', error);
          }
        );
      }
    }
    onSwitchMode(){
        this.isEditMode = !this.isEditMode;
    }

}
