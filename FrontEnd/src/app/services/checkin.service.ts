import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckInRequest, CheckInResponse } from '../models/checkin.model';

@Injectable({
  providedIn: 'root'
})
export class CheckInService {
  private apiUrl = 'http://localhost:5188/api/CheckInStatus/checkin';

  constructor(private http: HttpClient) { }

  checkIn(checkInRequest: CheckInRequest): Observable<CheckInResponse> {
    return this.http.post<CheckInResponse>(this.apiUrl, checkInRequest);
  }
}
