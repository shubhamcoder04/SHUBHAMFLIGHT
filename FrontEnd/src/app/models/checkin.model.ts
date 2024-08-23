export interface CheckInRequest {
    booking_Id: number;
    email: string;
  }
  
  export interface CheckInResponse {
    checkInId: number;
    bookingId: number;
    status: string;
    seatNumber: string;
    flightId: number;
    checkInStatus: boolean;
  }
  