import { Injectable } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';
import { Observable } from 'rxjs';
/*import { AuthService } from './auth.service';*/
 
export const JwtInterceptor:HttpInterceptorFn = (request,next)=> {
  //constructor(private authService: AuthService) { }
  const token = localStorage.getItem("token");
  //console.log("jwtinterceptor", token);
    request = request.clone({
      setHeaders: {
            'Authorization': `Bearer ${token}`
         }
    })
   
    return next(request);
  }