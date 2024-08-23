
import { Component } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { Booking } from 'src/app/models/booking.model';

@Component({
  selector: 'app-cancel-booking',
  templateUrl: './cancel-booking.component.html',
  styleUrls: ['./cancel-booking.component.css']
})
export class CancelBookingComponent {
  bookingId: number = 0;
  isSubmitted:boolean= false;
  successMessage: string = '';
  errorMessage: string = '';
  ticket:any;
  canceledBookingDetails: any = null; 

  constructor(private bookingService: BookingService, private authService: AuthService, private router: Router) { }

  fetchDetails(){
    this.bookingService.getBookingById(this.bookingId).subscribe(data=>{
      this.ticket=data;
      console.log(this.ticket);
      this.isSubmitted= true;
    })
  }
  reloadPage(){
    const currentUrl = this.router.url;
      // Navigate to the same route
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(
        () => {
          this.router.navigateByUrl(currentUrl);
        },
        (error) => {
          console.error('Error Booking Page', error);
        }
      );
  }
  cancelBooking(): void {
    if (this.authService.isLoggedIn()) {
      console.log("cancelled");
        this.bookingService.cancelBooking(this.bookingId).subscribe(
          (response) => {
             console.log('Ticket Cancelled ',this.bookingId);
              alert('Your flight got cancelled successfully.');
            this.reloadPage();

          },
            (error) => {
            console.error('Error canceling booking', error);
            this.errorMessage = 'Failed to cancel booking. Please check the booking ID and try again.';
            this.successMessage = '';
            this.canceledBookingDetails = null; 
          }
        );
    } else {
      alert("You are not Logged In!!!");
      this.router.navigate(['/login']);
    }
  }
}


