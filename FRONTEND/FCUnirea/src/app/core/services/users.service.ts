import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:5000/api/Users';
  private http = inject(HttpClient);

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(user: any): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, user);
  }

  getProfile(): Observable<any> {
    return this.http.get(`${this.apiUrl}/my-profile`);
  }

  changePassword(data: { currentPassword: string; newPassword: string }): Observable<any> {
    return this.http.post(`${this.apiUrl}/change-password`, data);
  }

  updateName(data: { firstName: string; lastName: string }) {
    return this.http.post(`${this.apiUrl}/update-name`, data);
  }
  
  updateUsername(username: string) {
    return this.http.post(`${this.apiUrl}/update-username`, { username });
  }
  
  updateEmail(email: string) {
    return this.http.post(`${this.apiUrl}/update-email`, { email });
  }
  
  updatePhone(phoneNumber: string) {
    return this.http.post(`${this.apiUrl}/update-phone`, { phoneNumber });
  }
  
  deleteAccount(): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete-account`);
  }
  
  getUserIdFromToken(): number | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
  
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.userId || null;
    } catch (e) {
      return null;
    }
  }
  //admin section
  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}`);
  }

  updateUser(user: any): Observable<any> {
    return this.http.put(`${this.apiUrl}`, user);
  }

  //sterge un user
  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  
  //ia rolul din token
  getRoleFromToken(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null;
    } catch (e) {
      return null;
    }
  }
  // verifica daca userul este admin
  isAdmin(): boolean {
    return this.getRoleFromToken() === 'Admin';
  }
}
