import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightSearchComponent } from './components/flight/flight-search.component';
 import { BookingComponent } from './components/booking/booking.component';
// import { UserComponent } from './components/user/user.component';
 import { CheckInComponent } from './components/checkin/checkin.component';
 import { UserRegistrationComponent } from './components/user-registration/user-registration.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { BookingConfirmationComponent } from './components/booking-confirmation/booking-confirmation.component';
import { FlightListComponent } from './components/flight-list/flight-list.component';
import { FlightFormComponent } from './components/flight-form/flight-form/flight-form.component';
import { ViewBookingComponent } from './components/view-booking/view-booking.component';
import { CancelBookingComponent } from './components/cancel-booking/cancel-booking.component';
import { HomeComponent } from './components/home/home.component';
import { AdminGuard } from './admin.guard';



const routes: Routes = [
  { path: 'flights', component: FlightSearchComponent },
   { path: 'bookings', component: BookingComponent },
  // { path: 'users', component: UserComponent },
  { path: 'register', component: UserRegistrationComponent },
  
  { path: 'login', component: UserLoginComponent },
  { path: 'booking-confirmation', component: BookingConfirmationComponent },
   { path: 'checkin', component: CheckInComponent },
   { path: 'search-results', component: SearchResultsComponent },
   { path: 'flights/all', component: FlightListComponent },
   { path: 'flight/add', component: FlightFormComponent,canActivate: [AdminGuard]  },
   { path: 'view-booking', component: ViewBookingComponent },
   { path: 'cancel-booking', component: CancelBookingComponent ,},
   { path: 'flight/:id', component: FlightFormComponent ,canActivate: [AdminGuard] },
  { path: '',component:HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
