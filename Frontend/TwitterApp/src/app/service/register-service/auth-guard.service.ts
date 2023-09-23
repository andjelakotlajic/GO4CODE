import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { RegisterService } from '../register-service/register.service';
import { Observable, map, take } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private regService: RegisterService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): 
  boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return this.regService.user.pipe(
      take(1),
      map((user) => {
        if(!user) {
          // vratimo false
          return this.router.createUrlTree(['/register']);
        }
        
        //vratimo true
        return true;
      })
    )
  }
}
