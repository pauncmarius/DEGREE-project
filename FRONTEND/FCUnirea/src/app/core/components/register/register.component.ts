import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})

export class RegisterComponent implements OnInit {
  myFirstNgModel: string | undefined;
  userFormGroup!: FormGroup;

  constructor(private activeRoute: ActivatedRoute) {}

  ngOnInit(): void {

      this.userFormGroup = new FormGroup({
        name: new FormControl('value default'),
        username: new FormControl(''),
        password: new FormControl(''),
        checkbox: new FormControl(false),
      });

      this.userFormGroup.valueChanges.subscribe((data) => {
        console.log('values', data);
      });

      this.userFormGroup.controls['name'].valueChanges.subscribe((data) => {
        console.log('value', data);
      })
  }

  onModelChange(event: string): void {
    console.log('valoare', event);
  }

  onSubmitForm(form: FormGroupDirective): void {
    console.log('submit', form);
  }
}

