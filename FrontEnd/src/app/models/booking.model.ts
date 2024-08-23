
export interface Booking {
    booking_Id: number;
    flight_ID: number;
    user_ID: number;
    total_Amount: number;
    transactionnum: string;
    datetime: Date;
    no_of_passengers: number;
    passengers: Passenger[];
  }
  
  export interface Passenger {
    name: string;
    age: number;
    gender: string;
  }
  