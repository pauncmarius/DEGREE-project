import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompetitionsModel } from '../models/competitions-model';

@Injectable({ providedIn: 'root' })
export class CompetitionService {
  private http = inject(HttpClient);
  private api = 'https://localhost:5000/api/Competitions';

  getAll(): Observable<CompetitionsModel[]> {
    return this.http.get<CompetitionsModel[]>(this.api);
  }

  add(competition: CompetitionsModel): Observable<any> {
    return this.http.post(this.api, competition);
  }

  update(competition: CompetitionsModel): Observable<any> {
    return this.http.put(this.api, competition);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.api}/${id}`);
  }
}
