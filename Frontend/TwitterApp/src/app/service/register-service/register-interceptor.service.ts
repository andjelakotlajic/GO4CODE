import { RegisterService } from './register.service';
import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { exhaustMap, take } from 'rxjs';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor{

  constructor(private regService: RegisterService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return this.regService.user.pipe(
      take(1),
      exhaustMap( user => {
        if(!user) {
          return next.handle(req);
        }

        let modifiedReq = req.clone({
          setHeaders: {
            'Authorization' : 'Bearer ' + user.token,
          }
        })

        return next.handle(modifiedReq);
      })
    )
  }
}