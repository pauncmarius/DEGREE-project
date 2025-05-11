import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class NewsService {
  private api = 'https://localhost:5000/api';
  private http = inject(HttpClient);

  getAllNews(): Observable<any[]> {
    return this.http.get<any[]>(`${this.api}/News`);
  }

  getNewsById(id: number): Observable<any> {
    return this.http.get<any>(`${this.api}/News/${id}`);
  }

  postComment(comment: { text: string; comment_NewsId: number }): Observable<any> {
    return this.http.post(`${this.api}/Comments`, comment);
  }

  deleteComment(id: number): Observable<any> {
    return this.http.delete(`${this.api}/Comments/${id}`);
  }

  addNews(news: any): Observable<any> {
    return this.http.post(`${this.api}/News`, news);
  }

  updateNews(news: any): Observable<any> {
    return this.http.put(`${this.api}/News`, news);
  }

  deleteNews(id: number): Observable<any> {
    return this.http.delete(`${this.api}/News/${id}`);
  }
}
