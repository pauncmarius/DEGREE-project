import { HttpClient } from "@angular/common/http";
import { GameForTicket } from "../models/game-ticket";
import { Seat } from "../models/seat-model";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class TicketingService {
  private apiUrl = 'https://localhost:5000/api';

  constructor(private http: HttpClient) {}

  getAvailableGames(): Observable<GameForTicket[]> {
    return this.http.get<GameForTicket[]>(`${this.apiUrl}/Games/home-upcoming`);
  }

  reserveTicket(ticket: {
    ticket_UsersId: number;
    ticket_GamesId: number;
    ticket_SeatsId: number;
  }): Observable<any> {
    return this.http.post(`${this.apiUrl}/Tickets`, ticket);
  }
}
