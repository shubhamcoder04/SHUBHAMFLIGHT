// import { Component } from '@angular/core';
// import { UserService } from '../../services/user.service';
// import { User } from '../../models/user.model';
// import { Router } from '@angular/router';

// @Component({
//   selector: 'app-user-login',
//   templateUrl: './user-login.component.html',
//   styleUrls: ['./user-login.component.css']
// })
// export class UserLoginComponent {
//   user: Partial<User> = { email: '', password: '' }; 
//   loginResponse: any;

//   constructor(private userService: UserService, private router:Router) {}

//   loginUser(): void {
//     if (this.user.email && this.user.password) {
//       this.userService.login(this.user.email, this.user.password).subscribe({
//         next:response => {
//         this.loginResponse = response;
//         console.log(response.token);
//         localStorage.setItem('token',response.token);
//         this.router.navigateByUrl('/')
//       }, 
//       error:error => {
//         console.error('Login failed', error);
//         this.loginResponse = { error: 'Login failed. Please try again.' };
//       },
//     });
//     }}
//   }


import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {
  user: Partial<User> = { email: '', password: '' };
  loginResponse: any;

  constructor(private userService: UserService, private router: Router) {}

  loginUser(): void {
    if (this.user.email && this.user.password) {
      this.userService.login(this.user.email, this.user.password).subscribe({
        next: response => {
          this.loginResponse = response;
          console.log(response.token);
          localStorage.setItem('token', response.token);
          this.router.navigateByUrl('/')
        },
        error: error => {
          console.error('Login failed', error);
          this.loginResponse = { error: 'Login failed. Please try again.' };
        },
      });
    }
  }
}
