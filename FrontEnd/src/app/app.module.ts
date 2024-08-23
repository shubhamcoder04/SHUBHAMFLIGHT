import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FlightSearchComponent } from './components/flight/flight-search.component';
import { BookingComponent } from './components/booking/booking.component';
import { CheckInComponent } from './components/checkin/checkin.component';
import { CheckInService } from './services/checkin.service';
import { UserRegistrationComponent } from './components/user-registration/user-registration.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { BookingConfirmationComponent } from './components/booking-confirmation/booking-confirmation.component';
import { FlightListComponent } from './components/flight-list/flight-list.component';
import { FlightFormComponent } from './components/flight-form/flight-form/flight-form.component';
import { ViewBookingComponent } from './components/view-booking/view-booking.component';
import { CancelBookingComponent } from './components/cancel-booking/cancel-booking.component';
import { HomeComponent } from './components/home/home.component';
import { JwtInterceptor } from './jwt-interceptor';

 //import { BookingComponent } from './components/booking/booking.component';
// import { UserComponent } from './components/user/user.component';
// import { CheckInComponent } from './components/checkin/checkin.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FlightSearchComponent,
    BookingComponent,
    CheckInComponent,
    UserRegistrationComponent,
    UserLoginComponent,
    SearchResultsComponent,
    BookingConfirmationComponent,
    FlightListComponent,
    FlightFormComponent,
    ViewBookingComponent,
    CancelBookingComponent,
    HomeComponent,
    
    // UserComponent,
    // CheckInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [provideHttpClient(withInterceptors([JwtInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule { }
