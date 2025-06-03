import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TicketInfo } from '../models/tickets-model';

@Injectable({ providedIn: 'root' })
export class TicketsService {
  private apiUrl = 'https://localhost:5000/api/Tickets';

  constructor(private http: HttpClient) {}

  getTicketsByUser(userId: number): Observable<TicketInfo[]> {
    return this.http.get<TicketInfo[]>(`${this.apiUrl}/byUser/${userId}`);
  }

  getTicketsByGame(gameId: number): Observable<TicketInfo[]> {
    return this.http.get<TicketInfo[]>(`${this.apiUrl}/game/${gameId}`);
  }
}
