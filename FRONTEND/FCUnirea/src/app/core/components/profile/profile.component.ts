import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user-service.service';
import { FormBuilder, ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  private userService = inject(UserService);
  private fb = inject(FormBuilder);

  profile: any;
  passwordForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor() {
    this.passwordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.userService.getProfile().subscribe(
      (data) => {
        this.profile = data;
        console.log('Profil:', data);
      },
      (error) => {
        console.error('Eroare profil:', error);
      }
    );
  }

  onChangePassword(): void {
    if (this.passwordForm.invalid) return;

    this.userService.changePassword(this.passwordForm.value).subscribe(
      () => {
        this.successMessage = 'Parola a fost schimbată cu succes.';
        this.errorMessage = '';
        this.passwordForm.reset();
      },
      () => {
        this.successMessage = '';
        this.errorMessage = 'Parola curentă este greșită.';
      }
    );
  }
}