import { Component } from '@angular/core';
import { ChatResponse, ChatService } from '../../services/chat.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface ChatMessage {
  sender: 'user' | 'ai';
  text: string;
  timestamp: Date;

}

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.scss'],
  standalone: true,
  imports: [
    FormsModule,
    HttpClientModule,
    CommonModule 
  ],
})
export class ChatboxComponent {
  messages: ChatMessage[] = [];
  userInput = '';
  loading = false;

  constructor(private chatService: ChatService) {}

  
  ngOnInit() {
    // la încărcarea componentei, trimitem un prompt special către AI ca să ne întoarcă automat un mesaj de întâmpinare.
    this.loading = true;
    const greetingPrompt = 'Generare mesaj de întâmpinare';
    this.chatService.ask(greetingPrompt).subscribe({
      next: (response: ChatResponse) => {
        this.messages.push({ sender: 'ai', text: response.reply, timestamp: new Date() });
        this.loading = false;
      },
      error: () => {
        this.messages.push({
          sender: 'ai',
          text: 'Bun venit! Se pare că nu mă pot conecta momentan la serverul AI, dar în curând voi fi din nou online!',
          timestamp: new Date()
        });
        this.loading = false;
      }
    });
  }

  sendMessage() {
    if (!this.userInput.trim()) return;
    const message = this.userInput;
    this.messages.push({ sender: 'user', text: message, timestamp: new Date() });
    this.userInput = '';
    this.loading = true;

    this.chatService.ask(message).subscribe({
      next: (response: ChatResponse) => {
        this.messages.push({ sender: 'ai', text: response.reply, timestamp: new Date() });
        this.loading = false;
      },
      error: (err) => {
        this.messages.push({ sender: 'ai', text: 'Eroare la comunicarea cu serverul AI.', timestamp: new Date() });
        this.loading = false;
      }
    });
  }
}
