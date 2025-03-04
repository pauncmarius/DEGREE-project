import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { AppComponent } from './app/app.component';
import { RegisterComponent } from './app/core/components/register/register.component';
import { PageNotFoundComponent } from './app/core/components/page-not-found/page-not-found.component';
import { UserSettingsComponent } from './app/features/users/user-settings/user-settings.component';
import { FirstGuard } from './app/shared/first.guard';
import { provideHttpClient } from '@angular/common/http';

const routes: Routes = [
  { path: '', redirectTo: 'register', pathMatch: 'full' },
  { path: 'register', canActivate: [FirstGuard], component: RegisterComponent },
  {path: 'users',
  children: [
    { path: 'overview', loadComponent: () => import('./app/features/users/user-overview/user-overview.component').then(m => m.UserOverviewComponent) },
    { path: 'settings', loadComponent: () => import('./app/features/users/user-settings/user-settings.component').then(m => m.UserSettingsComponent) }]
  },
  { path: '**', component: PageNotFoundComponent  }
];

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes), provideHttpClient()]
}).catch(err => console.error(err));
