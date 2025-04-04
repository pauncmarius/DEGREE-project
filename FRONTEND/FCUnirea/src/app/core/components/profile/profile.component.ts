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

  profileForm: FormGroup;
  isEditing = false;

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

    this.profileForm = this.fb.group({
      username: [{ value: '', disabled: true }, [Validators.required, Validators.minLength(3)]],
      email: [{ value: '', disabled: true }, [Validators.required, Validators.email]],
      firstName: [{ value: '', disabled: true }, Validators.required],
      lastName: [{ value: '', disabled: true }, Validators.required],
      phoneNumber: [{ value: '', disabled: true }, [Validators.required, Validators.pattern(/^\d{10}$/)]],
    });
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

  toggleEdit() {
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.profileForm.enable();
    } else {
      this.profileForm.disable();
    }
  }
  
  onSaveProfile(): void {
    if (this.profileForm.invalid) return;
  
    this.userService.updateProfile(this.profileForm.value).subscribe(
      () => {
        this.successMessage = 'Profil actualizat cu succes!';
        this.errorMessage = '';
        this.toggleEdit();
      },
      (error) => {
        this.successMessage = '';
        this.errorMessage = 'A apărut o eroare la actualizare.';
      }
    );
  }
}
