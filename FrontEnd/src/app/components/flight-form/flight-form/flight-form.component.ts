
import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Flight } from 'src/app/models/flight.model';
import { FlightService } from 'src/app/services/flight.service';


@Component({
  selector: 'app-flight-form',
  templateUrl: './flight-form.component.html',
  styleUrls: ['./flight-form.component.css']
})
export class FlightFormComponent implements OnInit {
  flightForm: FormGroup;
  isEditing: boolean = false;
  flightId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private flightService: FlightService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.flightForm = this.fb.group({
      airline: ['', Validators.required],
      source: ['', Validators.required],
      destination: ['', Validators.required],
      departure_Time: ['', Validators.required],
      arrival_Time: ['', Validators.required],
      total_Seats: [0, [Validators.required, Validators.min(1)]],
      fare: [0, [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.flightId = +params['id']; // Convert to number
      if (this.flightId) {
        this.isEditing = true;
        this.loadFlight();
      }
    });
  }

  loadFlight(): void {
    if (this.flightId) {
      this.flightService.getFlightById(this.flightId).subscribe(flight => {
        this.flightForm.patchValue(flight);
      });
    }
  }

  saveFlight(): void {
    console.log(this.flightForm.value);

    if (this.flightForm.valid) {
      const flight: Flight = {
        flight_ID: this.flightId || 0,
        ...this.flightForm.value
      };

      if (this.isEditing) {
        this.flightService.updateFlight(flight.flight_ID, flight).subscribe(() => {
          this.router.navigate(['/flights']);
        });
      } else {
        this.flightService.addFlight(flight).subscribe(() => {
          this.router.navigate(['/flights']);
        });
      }
    }
  }

  deleteFlight(): void {
    if (this.flightId) {
      this.flightService.deleteFlight(this.flightId).subscribe(() => {
        this.router.navigate(['/flights']);
      });
    }
  }
}
