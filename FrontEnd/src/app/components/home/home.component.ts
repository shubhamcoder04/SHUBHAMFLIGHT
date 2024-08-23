import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  flightId: number | null = null; // To hold the input value
  isAdmin:boolean = false

  constructor(private router: Router, private authService:AuthService) {}

  navigateToEditFlight(): void {
    if (this.flightId !== null) {
      this.router.navigate(['/flight', this.flightId]);
    }
  }

  ngOnInit(): void {
    this.isAdmin = this.authService.isAdmin();
  }
}
