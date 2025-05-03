import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from '../models/players-model';

@Injectable({ providedIn: 'root' })
export class PlayersService {
  private apiUrl = 'https://localhost:5000/api/Players';

  constructor(private http: HttpClient) {}

  getPlayersByTeam(teamId: number): Observable<Player[]> {
    return this.http.get<Player[]>(`${this.apiUrl}/byTeam/${teamId}`);
  }
}
