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
  getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(`${this.apiUrl}`);
  }
  addPlayer(player: Player): Observable<any> {
    return this.http.post(`${this.apiUrl}`, player);
  }
  deletePlayer(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  updatePlayer(player: Player): Observable<any> {
  return this.http.put(`${this.apiUrl}`, player);
}

}

