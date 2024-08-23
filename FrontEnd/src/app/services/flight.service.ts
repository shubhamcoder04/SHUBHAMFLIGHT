
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Flight } from '../models/flight.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  private apiUrl = 'http://localhost:5188/api/Flight'; 

  constructor(private http: HttpClient,private authservice:AuthService) { }

  getFlightById(id: number): Observable<Flight> {
    const headers = this.authservice.getAuthHeaders();
    
    return this.http.get<Flight>(`${this.apiUrl}/${id}`,{headers});
  }

  getAllFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.apiUrl);
  }

  searchFlights(source: string, destination: string, date: string): Observable<Flight[]> {
    return this.http.get<Flight[]>(`${this.apiUrl}/search`, {
      params: {
        source,
        destination,
        date
      }
    });
  }

  addFlight(flight: Flight): Observable<Flight> {
    return this.http.post<Flight>(this.apiUrl, flight);
  }

  updateFlight(id: number, flight: Flight): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, flight); 
  }

  deleteFlight(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
