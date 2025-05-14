import { inject } from '@angular/core';
import { CanActivateFn, ActivatedRouteSnapshot, Router } from '@angular/router';

export const teamAccessGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {
  const router = inject(Router);
  const token = localStorage.getItem('token');

  if (!token) {
    router.navigate(['/access-denied']);
    return false;
  }

  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    const teamId = Number(route.paramMap.get('id'));

    if (role === 'Admin') {
      return true;
    }

    const allowedTeamIds = [1, 11, 21];
    if (role === 'Customer' && allowedTeamIds.includes(teamId)) {
      return true;
    }

    router.navigate(['/access-denied']);
    return false;

  } catch {
    router.navigate(['/access-denied']);
    return false;
  }
};
