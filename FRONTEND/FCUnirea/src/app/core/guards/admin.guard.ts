import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const adminGuard: CanActivateFn = () => {
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (!token) {
    router.navigate(['/access-denied']);
    return false;
  }

  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    if (payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Admin') {
      return true;
    } else {
      router.navigate(['/access-denied']);
      return false;
    }
  } catch {
    router.navigate(['/access-denied']);
    return false;
  }
};
