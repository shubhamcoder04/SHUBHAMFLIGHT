
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { FlightService } from '../../services/flight.service';
import { Flight } from '../../models/flight.model';
import { AuthService } from '../../services/auth.service';
import * as moment from 'moment';

@Component({
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})
export class FlightSearchComponent implements OnInit {
  searchForm: FormGroup;
  flights: Flight[] = [];
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private flightService: FlightService,
    private router: Router,
    private authService: AuthService
  ) {
    this.searchForm = this.fb.group({
      source: ['', Validators.required],
      destination: ['', Validators.required],
      date: ['', [Validators.required, this.dateValidator]]
    }, { validators: this.sourceDestinationValidator });
  }

  ngOnInit(): void {}

  sourceDestinationValidator(form: FormGroup): ValidationErrors | null {
    const source = form.get('source')?.value;
    const destination = form.get('destination')?.value;

    if (source && destination && source === destination) {
      return { sameLocation: true };
    }
    return null;
  }

  dateValidator(control: AbstractControl): ValidationErrors | null {
    const selectedDate = moment(control.value);
    const now = moment();
    const twoMonthsFromNow = moment().add(2, 'months');

    if (selectedDate.isBefore(now, 'day')) {
      return { pastDate: true };
    }
    if (selectedDate.isAfter(twoMonthsFromNow, 'day')) {
      return { futureDate: true };
    }
    return null;
  }

  searchFlights(): void {
    if (this.searchForm.valid) {
      const { source, destination, date } = this.searchForm.value;
      this.flightService.searchFlights(source, destination, date).subscribe({
        next: (flights) => {
          this.flights = flights;
        },
        error: (error) => {
          console.error('Error searching flights', error);
        }
      });
    }
  }

  onBooking(flightId: number): void {
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/bookings'], { queryParams: { flight: flightId } });
    } else {
      this.router.navigate(['/login']);
    }
  }
}

