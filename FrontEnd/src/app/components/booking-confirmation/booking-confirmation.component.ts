import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../../services/booking.service';
import { FlightService } from '../../services/flight.service';
import { Booking } from '../../models/booking.model';
import { Flight } from '../../models/flight.model';

@Component({
  selector: 'app-booking-confirmation',
  templateUrl: './booking-confirmation.component.html',
  styleUrls: ['./booking-confirmation.component.css']
})
export class BookingConfirmationComponent implements OnInit {
  booking: Booking | undefined;
  flightDetails: Flight | null = null; // Variable to store flight details

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private flightService: FlightService // Inject the FlightService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const bookingId = params['bookingId'];
      this.loadBookingDetails(bookingId);
    });
  }

  loadBookingDetails(bookingId: number): void {
    this.bookingService.getBookingById(bookingId).subscribe(
      (booking: Booking) => {
        this.booking = booking;
        if (this.booking) {
          this.getFlightDetails(this.booking.flight_ID);
        }
      },
      error => {
        console.error('Error loading booking details', error);
      }
    );
  }

  getFlightDetails(id: number): void {
    this.flightService.getFlightById(id).subscribe(
      (flight: Flight) => {
        this.flightDetails = flight;
      },
      error => {
        console.error('Error fetching flight details', error);
      }
    );
  }
}
