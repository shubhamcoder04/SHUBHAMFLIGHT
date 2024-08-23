
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { jwtDecode } from 'jwt-decode';

interface DecodedToken {
  email: string;
  nameid: string;
  role: string;
}
@Injectable({
  providedIn: 'root'
})


export class UserService {
  private apiUrl = 'http://localhost:5188/api/User'; // Adjust the URL if needed

  constructor(private http: HttpClient) {
    console.log(this.getUserId());
   }

  register(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/register`, user);
  }

  login(email: string, password: string) {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { email, password });
  }

  getEmail(): string {
    const token = localStorage.getItem('token');

    if (!token) {
      console.error("No token found in localStorage");
      return "";
    }

    try {
      const decoded: DecodedToken = jwtDecode(token);

      return decoded.email;
    } catch (error) {
      console.error("Failed to decode token", error);
      return "";
    }
  }
  getUserId(): number {
    const token = localStorage.getItem('token');

    if (!token) {
      console.error("No token found in localStorage");
      return 0;
    }


    try {
      const decoded: DecodedToken = jwtDecode(token);

      const id: number = parseInt(decoded.nameid, 10); // 10 is the base for decimal numbers
      console.log(id);
      return id;
    } 
    catch (error) {
      console.error("Failed to decode token", error);
    }
    return 0;

  }

  getUserById(id: number): Observable<User> {

    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }

}
