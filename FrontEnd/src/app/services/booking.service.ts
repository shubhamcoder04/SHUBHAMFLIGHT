// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';
// import { Booking } from '../models/booking.model';

// @Injectable({
//   providedIn: 'root'
// })
// export class BookingService {
//   private apiUrl = 'http://localhost:5188/api/BookingDetails';

//   constructor(private http: HttpClient) {}

//   bookFlight(booking: Booking): Observable<Booking> {
//     return this.http.post<Booking>(this.apiUrl, booking);
//   }

//   getBookingById(id: number): Observable<Booking> {
//     return this.http.get<Booking>(`${this.apiUrl}/${id}`);
//   }
// }

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = 'http://localhost:5188/api/BookingDetails';

  constructor(private http: HttpClient, private authService: AuthService) { }

  bookFlight(booking: Booking): Observable<Booking> {
    const headers = this.authService.getAuthHeaders();
    return this.http.post<Booking>(this.apiUrl, booking, { headers });
  }

  getBookingById(id: number): Observable<Booking> {
    return this.http.get<Booking>(`${this.apiUrl}/${id}`);
  }

  cancelBooking(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/cancel/${id}`);
  }

}