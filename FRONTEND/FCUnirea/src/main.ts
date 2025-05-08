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
import { TeamsComponent } from './app/core/components/teams/teams.component';
import { TeamDetailsComponent } from './app/core/components/team-details/team-details.component';
import { MyTicketsComponent } from './app/core/components/my-tickets/my-tickets.component';


const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [authGuard]},
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
  { path: 'teams', component: TeamsComponent , canActivate: [authGuard]},
  { path: 'my-tickets', component: MyTicketsComponent , canActivate: [authGuard]},
  { path: 'teams/:id', component: TeamDetailsComponent, canActivate: [authGuard] },
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