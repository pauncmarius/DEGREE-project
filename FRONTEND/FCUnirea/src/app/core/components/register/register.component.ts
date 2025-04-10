import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { UserService } from '../../services/users.service';

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
        console.log('Server error:', error); // 👈 păstrează pentru debugging
    
        if (error.status === 400 && error.error && error.error.errors) {
          const errors = error.error.errors;
    
          // Resetăm erorile existente
          Object.keys(this.registerForm.controls).forEach(field => {
            this.registerForm.get(field)?.setErrors(null);
          });
    
          // Setăm erorile specifice venite de la backend
          if (errors.username) {
            this.registerForm.get('username')?.setErrors({ server: errors.username });
          }
          if (errors.email) {
            this.registerForm.get('email')?.setErrors({ server: errors.email });
          }
          if (errors.phoneNumber) {
            this.registerForm.get('phoneNumber')?.setErrors({ server: errors.phoneNumber });
          }
    
        } else {
          this.errorMessage = 'A apărut o eroare de server.';
        }
      }
    );
  }


}
