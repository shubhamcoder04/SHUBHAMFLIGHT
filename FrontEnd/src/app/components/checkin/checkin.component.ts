import { Component } from '@angular/core';
import { CheckInService } from '../../services/checkin.service';
import { CheckInRequest, CheckInResponse } from '../../models/checkin.model';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkin',
  templateUrl: './checkin.component.html',
  styleUrls: ['./checkin.component.css']
})
export class CheckInComponent {
  checkInRequest: CheckInRequest = {
    booking_Id: 0,
    email: ''
  };
  checkInResponse: CheckInResponse | null = null;
  errorMessage: string | null = null;

  constructor(private checkInService: CheckInService, private authService: AuthService, private router: Router) { }

  onCheckIn(): void {
    if (this.authService.isLoggedIn()) {
      this.checkInService.checkIn(this.checkInRequest).subscribe(
        response => {
          this.checkInResponse = response;
          this.errorMessage = null;
        },
        error => {
          this.errorMessage = 'Check-in failed. Please try again.';
          this.checkInResponse = null;
        }
      );
    } else {
      alert("You are not Logged In!!!")
      this.router.navigate(['/login']);
    }
  }
}
