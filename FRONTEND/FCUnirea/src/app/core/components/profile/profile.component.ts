import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user-service.service';
import { FormBuilder, ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';

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

  profile: any = {};
  passwordForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  nameForm = this.fb.group({
    firstName: [''],
    lastName: ['']
  });
  
  usernameControl = this.fb.control('', [Validators.required, Validators.minLength(4)]);
  emailControl = this.fb.control('', [Validators.required, Validators.email]);
  phoneControl = this.fb.control('', [Validators.required, Validators.pattern(/^\d{10}$/)]);
  
  editUsername = false;
  editEmail = false;
  editPhone = false;
  
  usernameError = '';
  emailError = '';
  phoneError = '';


  constructor() {
    this.passwordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.userService.getProfile().subscribe((data) => {
      this.profile = data;
  
      this.nameForm.patchValue({
        firstName: data.firstName,
        lastName: data.lastName
      });
  
      this.usernameControl.setValue(data.username);
      this.emailControl.setValue(data.email);
      this.phoneControl.setValue(data.phoneNumber);
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

  onSaveName() {
    if (this.nameForm.valid) {
      this.userService.updateName({
        firstName: this.nameForm.value.firstName || '',
        lastName: this.nameForm.value.lastName || ''
      }).subscribe(() => {
        this.profile.firstName = this.nameForm.value.firstName;
        this.profile.lastName = this.nameForm.value.lastName;
      });
    }
  }
  
  toggleEdit(field: string) {
    const value = {
      username: this.usernameControl.value,
      email: this.emailControl.value,
      phoneNumber: this.phoneControl.value
    };
  
    if (field === 'username') {
      if (this.editUsername && this.usernameControl.valid) {
        this.userService.updateUsername(value.username || '').subscribe({
          next: () => {
            this.profile.username = value.username;
            this.usernameError = '';
          },
          error: (err) => {
            this.usernameError = err.error.message || 'Eroare necunoscută';
          }
        });
      }
      this.editUsername = !this.editUsername;
    }
  
    if (field === 'email') {
      if (this.editEmail && this.emailControl.valid) {
        this.userService.updateEmail(value.email || '').subscribe({
          next: () => {
            this.profile.email = value.email;
            this.emailError = '';
          },
          error: (err) => {
            this.emailError = err.error.message || 'Eroare necunoscută';
          }
        });
      }
      this.editEmail = !this.editEmail;
    }
  
    if (field === 'phone') {
      if (this.editPhone && this.phoneControl.valid) {
        this.userService.updatePhone(value.phoneNumber || '').subscribe({
          next: () => {
            this.profile.phoneNumber = value.phoneNumber;
            this.phoneError = '';
          },
          error: (err) => {
            this.phoneError = err.error.message || 'Eroare necunoscută';
          }
        });
      }
      this.editPhone = !this.editPhone;
    }
  }
}