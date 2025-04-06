import { Injectable, inject } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private router = inject(Router);

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');

    if (token) {
      const payload = this.decodePayload(token);
      const now = Math.floor(Date.now() / 1000); // secunde

      if (payload?.exp && now >= payload.exp) {
        alert('Sesiunea ta a expirat. Vei fi redirecționat.');
        localStorage.removeItem('token');
        this.router.navigate(['/']);
        return throwError(() => new Error('Token expirat'));
      }

      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(req).pipe(
      catchError(err => {
        if (err.status === 401) {
          localStorage.removeItem('token');
          this.router.navigate(['/']);
        }
        return throwError(() => err);
      })
    );
  }

  private decodePayload(token: string): any | null {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split('')
          .map(c => `%${('00' + c.charCodeAt(0).toString(16)).slice(-2)}`)
          .join('')
      );
      return JSON.parse(jsonPayload);
    } catch (e) {
      return null;
    }
  }
}
