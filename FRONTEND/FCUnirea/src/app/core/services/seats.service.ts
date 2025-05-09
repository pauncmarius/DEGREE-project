import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Seat } from '../models/seat-model';

@Injectable({ providedIn: 'root' })
export class SeatsService {
  private apiUrl = 'https://localhost:5000/api/Seats';

  constructor(private http: HttpClient) {}

  getSeatsByGame(gameId: number): Observable<Seat[]> {
    return this.http.get<Seat[]>(`${this.apiUrl}/forGame/${gameId}`);
  }
}
