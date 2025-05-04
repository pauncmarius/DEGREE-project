import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { TeamStatistic } from "../models/team-stats-model";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class TeamStatisticsService {
  private apiUrl = 'https://localhost:5000/api/TeamStatistics';

  constructor(private http: HttpClient) {}

  getStandingsByCompetition(competitionId: number): Observable<TeamStatistic[]> {
    return this.http.get<TeamStatistic[]>(`${this.apiUrl}/standings/${competitionId}`);
  }  

  getStandingsByTeamId(teamId: number): Observable<TeamStatistic[]> {
    return this.http.get<TeamStatistic[]>(`https://localhost:5000/api/TeamStatistics/standings/${teamId}`);
  }
  
}
