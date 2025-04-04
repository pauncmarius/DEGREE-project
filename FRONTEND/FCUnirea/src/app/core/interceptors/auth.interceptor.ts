import { Injectable, inject } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private router = inject(Router);

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = localStorage.getItem('token');

    if (token) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(req).pipe(
      catchError(err => {
        if (err.status === 401) {
          console.log('401 interceptat! Sterg tokenul și redirecționez...');
          localStorage.removeItem('token');
          setTimeout(() => {
            this.router.navigate(['/']);
          });
          localStorage.getItem('token');
        }
        return throwError(() => err);
      })
    );
  }
}
