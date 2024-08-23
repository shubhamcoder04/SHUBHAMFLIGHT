import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'token';
  constructor(private router:Router) { }


  
  isAdmin(): boolean {
    const token = localStorage.getItem(this.tokenKey);
    if (!token) {
      return false;
    }
    const decodedToken: any = jwtDecode(token);
    // Assuming the token contains an email field
    console.log(decodedToken.role);
    return decodedToken.role =="Admin";
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token'); // Check if userToken exists in local storage
  }


logout(){
  this.tokenKey="";
  localStorage.removeItem('token');
  this.router.navigate(['/login']);
}
getAuthHeaders(): HttpHeaders {
  return new HttpHeaders({
    Authorization: `Bearer ${localStorage.getItem(this.tokenKey)}`
  });
}


}
