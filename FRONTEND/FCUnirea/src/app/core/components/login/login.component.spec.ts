import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginComponent } from './login.component';
import { UserService } from '../../services/users.service';
import { ActivatedRoute, Router, provideRouter } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { of, throwError } from 'rxjs';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    localStorage.clear();

    await TestBed.configureTestingModule({
      imports: [
        LoginComponent,
        ReactiveFormsModule,
        FormsModule,
        HttpClientTestingModule
      ],
      providers: [
        provideRouter([]),  // esențial pentru routerLink
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: { params: {}, data: {} },
            paramMap: of({ get: () => null }),
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the login component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the login form with empty fields', () => {
    expect(component.loginForm.value).toEqual({ username: '', password: '' });
  });

    it('should not submit the form if invalid (fields empty)', () => {
    spyOn(component, 'onSubmit').and.callThrough();
    component.loginForm.setValue({ username: '', password: '' });
    component.onSubmit();
    expect(component.onSubmit).toHaveBeenCalled();
    expect(component.loginForm.valid).toBeFalse();
    expect(component.errorMessage).toBe('');
  });

  it('should submit the form if valid', () => {
    spyOn(component, 'onSubmit').and.callThrough();
    component.loginForm.setValue({ username: 'test ', password: 'testparola' });
    component.onSubmit();
    expect(component.onSubmit).toHaveBeenCalled();
    expect(component.loginForm.valid).toBeTrue();
  });

  it('should call loginUser on UserService when form is submitted', () => {
    const userService = TestBed.inject(UserService);
    spyOn(userService, 'login').and.returnValue(of({ token: 'fake' }));
    component.loginForm.setValue({ username: 'paunul', password: 'parola' });
    component.onSubmit();
    expect(userService.login).toHaveBeenCalledWith({ username: 'paunul', password: 'parola' });
    expect(component.errorMessage).toBe(''); 
  });

  it('should handle error when loginUser fails', () => {
    const userService = TestBed.inject(UserService);
    spyOn(userService, 'login').and.returnValue(throwError(() => new Error('Login failed')));
    component.loginForm.setValue({ username: 'paunul', password: 'parola1' });
    component.onSubmit();
    expect(userService.login).toHaveBeenCalledWith({ username: 'paunul', password: 'parola1' });
    expect(component.errorMessage).toBe('Credentialele sunt incorecte!'); 
  });

  it('should redirect to home on successful login', () => {
    const userService = TestBed.inject(UserService);
    const router = TestBed.inject(Router);
    spyOn(userService, 'login').and.returnValue(of({ token: 'fake' }));
    spyOn(router, 'navigate');
    component.loginForm.setValue({ username: 'paunul', password: 'parola' });
    component.onSubmit();
    expect(router.navigate).toHaveBeenCalledWith(['/home']);
  });

  it('should integrate: fill form, login, and redirect to home', async () => {
    const userService = TestBed.inject(UserService);
    const router = TestBed.inject(Router);
    spyOn(userService, 'login').and.returnValue(of({ token: 'fake-jwt' }));
    spyOn(router, 'navigate');

    // simulează completarea reală a formularului din HTML
    const usernameInput: HTMLInputElement = fixture.nativeElement.querySelector('input[formControlName="username"]');
    const passwordInput: HTMLInputElement = fixture.nativeElement.querySelector('input[formControlName="password"]');
    usernameInput.value = 'user1';
    passwordInput.value = 'pass123';
    usernameInput.dispatchEvent(new Event('input'));
    passwordInput.dispatchEvent(new Event('input'));
    fixture.detectChanges();

    // simulează apăsarea pe butonul de login
    const loginButton: HTMLButtonElement = fixture.nativeElement.querySelector('button[type="submit"]');
    loginButton.click();
    fixture.detectChanges();

    // așteaptă ca logica asincronă să se finalizeze
    await fixture.whenStable();

    // verifică rezultatul integrat: serviciul a fost chemat, nu există eroare, redirecționarea s-a făcut
    expect(userService.login).toHaveBeenCalledWith({ username: 'user1', password: 'pass123' });
    expect(component.errorMessage).toBe('');
    expect(router.navigate).toHaveBeenCalledWith(['/home']);
  });

});
