import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NewsService } from '../../services/news.service';
import { NewsModel } from '../../models/news-model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  private newsService = inject(NewsService);

  newsList: NewsModel[] = [];
  selectedNews: NewsModel | null = null;

  newCommentText = '';
  isLoggedIn = !!localStorage.getItem('token');
  successMessage = '';
  errorMessage = '';

  constructor() {
    this.loadNewsList();
  }

  loadNewsList(): void {
    this.newsService.getAllNews().subscribe((data) => {
      this.newsList = data;
    });
  }

  selectNews(news: any): void {
    if (this.selectedNews?.id === news.id) {
      this.selectedNews = null; // dacă e deja selectată, o închidem
    } else {
      this.newsService.getNewsById(news.id).subscribe((data) => {
        this.selectedNews = data;
        this.successMessage = '';
        this.errorMessage = '';
      });
    }
  }
  

  addComment(): void {
    if (!this.newCommentText.trim()) return;
  
    this.newsService.postComment({
      text: this.newCommentText,
      comment_NewsId: this.selectedNews?.id ?? 0
    }).subscribe({
      next: () => {
        this.successMessage = 'Comentariu adăugat cu succes!';
        this.errorMessage = '';
        this.newCommentText = '';
  
        // reîncarcă datele fără a trece prin toggle
        if (this.selectedNews?.id) {
          this.newsService.getNewsById(this.selectedNews.id).subscribe((data) => {
            this.selectedNews = data;
          });
        }
      },
      error: () => {
        this.errorMessage = 'A apărut o eroare la postarea comentariului.';
        this.successMessage = '';
      }
    });
  }
  
  
}
