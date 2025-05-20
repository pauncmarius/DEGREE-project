import { Component } from '@angular/core';

interface ChatMessage {
  sender: 'user' | 'ai';
  text: string;
}

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.css'],
  standalone: true
})
export class ChatboxComponent {
  messages: ChatMessage[] = [];
  userInput = '';
  loading = false;

  // Inlocuieste cu serviciul tau real cand ai backend
  async sendMessage() {
    if (!this.userInput.trim()) return;
    const message = this.userInput;
    this.messages.push({ sender: 'user', text: message });
    this.userInput = '';
    this.loading = true;

    // aici va fi requestul catre backend (deocamdata simulare)
    setTimeout(() => {
      this.messages.push({ sender: 'ai', text: 'Simulare raspuns AI. Aici vei vedea raspunsul real.' });
      this.loading = false;
    }, 1000);
  }
}
