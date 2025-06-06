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
import { TicketingComponent } from './app/core/components/ticketing/ticketing.component';
import { AdminUsersComponent } from './app/core/components/admin-users/admin-users.component';
import { adminGuard } from './app/core/guards/admin.guard';
import { AdminCompetitionsComponent } from './app/core/components/admin-competitions/admin-competitions.component';
import { AdminPlayersComponent } from './app/core/components/admin-players/admin-players.component';
import { AdminTeamsComponent } from './app/core/components/admin-teams/admin-teams.component';
import { AdminGamesComponent } from './app/core/components/admin-games/admin-games.component';
import { teamAccessGuard } from './app/core/guards/team-access.guard';


const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [authGuard]},
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [authGuard]},
  { path: 'teams', component: TeamsComponent , canActivate: [authGuard]},
  { path: 'my-tickets', component: MyTicketsComponent , canActivate: [authGuard]},
  { path: 'ticketing', component: TicketingComponent , canActivate: [authGuard]},
  { path: 'teams/:id', component: TeamDetailsComponent, canActivate: [authGuard, teamAccessGuard] },
  { path: 'admin/users', component: AdminUsersComponent, canActivate: [authGuard, adminGuard] },
  { path: 'admin/competitions', component: AdminCompetitionsComponent, canActivate: [authGuard, adminGuard] },
  { path: 'admin/players', component: AdminPlayersComponent, canActivate: [authGuard, adminGuard] },
  { path: 'admin/teams', component: AdminTeamsComponent, canActivate: [authGuard, adminGuard] },
  { path: 'admin/games', component: AdminGamesComponent, canActivate: [authGuard, adminGuard] },

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