
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookingService } from '../../services/booking.service';
import { FlightService } from '../../services/flight.service'; 
import { Booking, Passenger } from '../../models/booking.model';
import { Flight } from '../../models/flight.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  booking: Booking = {
    booking_Id: 0,
    flight_ID: 0,
    user_ID: this.userService.getUserId(),
    passengers: [],
    no_of_passengers: 0,
    total_Amount: 0,
    transactionnum: '',
    datetime: new Date()
  };
  flightDetails: Flight | null = null; // Variable to store flight details
  maxPassengers: number = 4;

  constructor(
    private userService:UserService,
    private bookingService: BookingService,
    private flightService: FlightService, // Inject the FlightService
    private router: Router,
    private route: ActivatedRoute
  ) {
    
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.booking.flight_ID = params['flight'];
      this.getFlightDetails(this.booking.flight_ID);
    });
  }

  getFlightDetails(id: number): void {
    this.flightService.getFlightById(id).subscribe(
      (flight: Flight) => {
        this.flightDetails = flight;
        // Calculate total amount based on passengers and flight fare
        this.booking.total_Amount = this.calculateTotalAmount();
      },
      error => {
        console.error('Error fetching flight details', error);
      }
    );
  }

  calculateTotalAmount(): number {
    if (this.flightDetails) {
      return this.flightDetails.fare * this.booking.passengers.length;
    }
    return 0;
  }

  checkMaxPass(): boolean {
    return (this.booking.passengers.length >= this.maxPassengers);
  }

  addPassenger(): void {
    if (this.checkMaxPass()) {
      alert('Maximum number of passengers reached');
      return;
    }
    this.booking.passengers.push({
      name: '',
      age: 0,
      gender: ''
    });
    this.booking.total_Amount = this.calculateTotalAmount();
  }

  removePassenger(index: number): void {
    this.booking.passengers.splice(index, 1);
    this.booking.total_Amount = this.calculateTotalAmount();
  }

  bookFlight(): void {
    if (this.booking.passengers.length === 0) {
      alert('Please add at least one passenger before booking.');
      return;
    }

    this.booking.no_of_passengers = this.booking.passengers.length;
    this.bookingService.bookFlight(this.booking).subscribe(
      response => {
        console.log('Booking successful', response);
        this.router.navigate(['/booking-confirmation'], { queryParams: { bookingId: response.booking_Id } });
      },
      error => {
        console.error('Booking failed', error);
      }
    );
  }

  continueBooking(): void {
    this.router.navigate(['/booking-confirmation'], { queryParams: { bookingId: this.booking.booking_Id } });
  }
}
