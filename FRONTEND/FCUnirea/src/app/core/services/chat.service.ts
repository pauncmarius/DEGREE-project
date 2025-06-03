import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ChatRequest {
  message: string;
  timestamp: Date;

}

export interface ChatResponse {
  reply: string;
  timestamp: Date;

}

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private apiUrl = 'https://localhost:5000/api/chat/ask'; 

  constructor(private http: HttpClient) {}

  ask(message: string): Observable<ChatResponse> {
    return this.http.post<ChatResponse>(this.apiUrl, { message });
  }
}
