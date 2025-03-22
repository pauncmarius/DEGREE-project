import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { UserService } from '../../services/user-service.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMessage: string = '';

  private fb = inject(FormBuilder);
  private userService = inject(UserService);
  private router = inject(Router);

  constructor() {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]]
    });
  }

  onSubmit(): void {
    if (this.registerForm.invalid) return;

    this.userService.register(this.registerForm.value).subscribe(
      () => {
        alert('Înregistrare reușită! Acum vă puteți autentifica.');
        this.router.navigate(['/login']);
      },
      (error) => {
        if (error.status === 400 && error.error) {
          const errors = error.error; // Obiectul JSON cu erori individuale

          // Resetăm erorile anterioare
          this.registerForm.get('username')?.setErrors(null);
          this.registerForm.get('email')?.setErrors(null);
          this.registerForm.get('phoneNumber')?.setErrors(null);

          // Setăm erorile individuale doar pentru câmpurile afectate
          if (errors.username) {
            this.registerForm.get('username')?.setErrors({ usernameExists: true });
          }
          if (errors.email) {
            this.registerForm.get('email')?.setErrors({ emailExists: true });
          }
          if (errors.phoneNumber) {
            this.registerForm.get('phoneNumber')?.setErrors({ phoneExists: true });
          }
        } else {
          this.errorMessage = 'A apărut o eroare!';
        }
      }
    );
  }


}
