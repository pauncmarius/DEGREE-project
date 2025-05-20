import { Component } from '@angular/core';
import { ChatResponse, ChatService } from '../../services/chat.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface ChatMessage {
  sender: 'user' | 'ai';
  text: string;
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

  sendMessage() {
    if (!this.userInput.trim()) return;
    const message = this.userInput;
    this.messages.push({ sender: 'user', text: message });
    this.userInput = '';
    this.loading = true;

    this.chatService.ask(message).subscribe({
      next: (response: ChatResponse) => {
        this.messages.push({ sender: 'ai', text: response.reply });
        this.loading = false;
      },
      error: (err) => {
        this.messages.push({ sender: 'ai', text: 'Eroare la comunicarea cu serverul AI.' });
        this.loading = false;
      }
    });
  }
}
