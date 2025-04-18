import { Routes } from '@angular/router';
import { RegisterComponent } from './app/core/components/register/register.component';
import { PageNotFoundComponent } from './app/core/components/page-not-found/page-not-found.component';
import { LoginComponent } from './app/core/components/login/login.component';
import { LandingComponent } from './app/core/components/landing/landing.component';
import { HomeComponent } from './app/core/components/home/home.component';
import { authGuard } from './app/core/guards/auth.guard';
import { AccessDeniedComponent } from './app/core/components/access-denied/access-denied.component';
import { ProfileComponent } from './app/core/components/profile/profile.component';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptorsFromDi, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { AuthInterceptor } from './app/core/interceptors/auth.interceptor';


const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [authGuard]},
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
  { path: '**', component: PageNotFoundComponent},

];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    }
  ]
});