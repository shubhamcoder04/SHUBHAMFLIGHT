import { Component } from '@angular/core';
import { BookingService } from '../../services/booking.service';
import { Booking } from '../../models/booking.model';

@Component({
  selector: 'app-view-booking',
  templateUrl: './view-booking.component.html',
  styleUrls: ['./view-booking.component.css']
})
export class ViewBookingComponent {
  bookingId: string = '';
  bookingDetails: any = null;
  errorMessage: string = '';

  constructor(private bookingService: BookingService) {}

  viewBooking(): void {
    const id = Number(this.bookingId);
    if (isNaN(id)) {
      this.errorMessage = 'Invalid booking ID. Please enter a valid number.';
      this.bookingDetails = null;
      return;
    }

    this.bookingService.getBookingById(id).subscribe(
      (details) => {
        this.bookingDetails = details;
        console.log(this.bookingDetails);
        // this.bookingDetails.transactionnum=details.transactionnum;
        this.bookingDetails.transactionnum = Math.floor(1000000000 + Math.random() * 9000000000).toString();
        this.errorMessage = '';
      },
      (error) => {
        console.error('Error fetching booking details', error);
        this.errorMessage = 'Booking not found. Please check the booking ID and try again.';
        this.bookingDetails = null;
      }
    );
  }
}
