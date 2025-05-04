import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Scorer } from "../models/scorers-model";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class PlayerStatsService {
  private apiUrl = 'https://localhost:5000/api/PlayerStatisticsPerCompetition';

  constructor(private http: HttpClient) {}

  getTopScorersByCompetition(competitionId: number): Observable<Scorer[]> {
    return this.http.get<Scorer[]>(`${this.apiUrl}/scorers/${competitionId}`);
  }
}
