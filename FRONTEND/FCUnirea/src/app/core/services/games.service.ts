import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../models/games-model';

@Injectable({ providedIn: 'root' })
export class GamesService {
  private apiUrl = 'https://localhost:5000/api/Games';

  constructor(private http: HttpClient) {}

  getGamesByTeam(teamId: number): Observable<Game[]> {
    return this.http.get<Game[]>(`${this.apiUrl}/byTeam/${teamId}`);
  }
  
  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(`${this.apiUrl}/withNames`);
  }
}
