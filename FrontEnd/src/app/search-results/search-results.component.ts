
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Flight } from '../models/flight.model';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
  flights: Flight[] = [];

  constructor(
    private flightService: FlightService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const source = params['source'];
      const destination = params['destination'];
      const date = params['date'];
      if (source && destination && date) {
        this.flightService.searchFlights(source, destination, date).subscribe(
          (flights: Flight[]) => {
            this.flights = flights;
          },
          error => {
            console.error('Error fetching flights', error);
          }
        );
      }
    });
  }

  bookFlight(flight: Flight): void {
    this.router.navigate(['/booking'], { queryParams: { flightId: flight.flight_ID } });
  }
}
