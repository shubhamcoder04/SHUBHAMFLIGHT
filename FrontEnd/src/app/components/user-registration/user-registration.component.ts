import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent {
  registrationForm: FormGroup;
  registrationResponse: any;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) {
    this.registrationForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phone_no: ['', [Validators.required, Validators.pattern(/^[0-9]{10}$/)]],
      role: ['User', Validators.required]
    });
  }

  registerUser(): void {
    this.submitted = true;
    if (this.registrationForm.valid) {
      this.userService.register(this.registrationForm.value).subscribe({
        next: (response) => {
          this.registrationResponse = response;
          this.router.navigate(['/login']); // Redirect to login page after successful registration
        },
        error: (err) => {
          console.error('Registration failed', err);
          this.registrationResponse = { error: 'Registration failed. Please try again.' };
        }
      });
    } else {
      this.registrationForm.markAllAsTouched();
    }
  }
}
