import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Team } from '../models/teams-model';

@Injectable({ providedIn: 'root' })
export class TeamService {
  private apiUrl = 'https://localhost:5000/api/Teams';

  constructor(private http: HttpClient) {}

  getInternalTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(`${this.apiUrl}/internal`);
  }

  getTeamById(id: number): Observable<Team> {
    return this.http.get<Team>(`${this.apiUrl}/${id}`);
  }
}
