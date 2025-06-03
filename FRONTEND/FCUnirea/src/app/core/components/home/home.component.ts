import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NewsService } from '../../services/news.service';
import { NewsModel } from '../../models/news-model';
import { Router } from '@angular/router';

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
  editingNews: any = { title: '', text: '' };

  newCommentText = '';
  isLoggedIn = !!localStorage.getItem('token');
  isAdmin = this.getRoleFromToken() === 'Admin';

  successMessage = '';
  errorMessage = '';

  searchTerm: string = '';
  filteredNews: NewsModel[] = [];

  constructor(private router: Router) {
    this.loadNewsList();}

  getUserIdFromToken(): number | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] || null;
    } catch (e) {
      return null;
    }
  }

  getRoleFromToken(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || null;
    } catch (e) {
      return null;
    }
  }

  loadNewsList(): void {
    this.newsService.getAllNews().subscribe(data => {
      this.newsList = data;
      this.filterNews();
    });
  }

  selectNews(news: any): void {
    if (this.selectedNews?.id === news.id) {
      this.selectedNews = null;
    } else {
      this.newsService.getNewsById(news.id).subscribe(data => {
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
        this.successMessage = 'Comentariu adăugat!';
        this.newCommentText = '';
        if (this.selectedNews?.id) this.selectNews(this.selectedNews);
      },
      error: () => {
        this.errorMessage = 'Eroare la postare comentariu.';
      }
    });
  }

  editNews(news: any): void {
    this.editingNews = { ...news };
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  cancelEdit(): void {
    this.editingNews = { title: '', text: '' };
  }

  submitNews(): void {
    this.editingNews.news_UsersId = this.getUserIdFromToken();
    if (this.editingNews.id) {
      this.newsService.updateNews(this.editingNews).subscribe(() => {
        this.loadNewsList();
        this.cancelEdit();
      });
    } else {
      this.newsService.addNews(this.editingNews).subscribe(() => {
        this.loadNewsList();
        this.cancelEdit();
      });
    }
  }

  deleteNews(id: number): void {
    if (confirm('Ești sigur că vrei să ștergi această știre?')) {
      this.newsService.deleteNews(id).subscribe(() => {
        this.loadNewsList();
        this.selectedNews = null;
      });
    }
  }

  deleteComment(id: number): void {
    if (confirm('Ștergi comentariul?')) {
      this.newsService.deleteComment(id).subscribe(() => {
        if (this.selectedNews?.id) this.selectNews(this.selectedNews);
      });
    }
  }

  parseNewsText(text: string): string {
  if (!text) return '';
  // Transformă boldul
  let html = text.replace(/\*\*(.+?)\*\*/g, '<strong>$1</strong>');
  // Poți adăuga și alte conversii dacă vrei (italic etc)
  return html;
  }

  filterNews(): void {
    const term = this.searchTerm.trim().toLowerCase();
    if (!term) {
      this.filteredNews = this.newsList;
      return;
    }
    this.filteredNews = this.newsList.filter(news =>
      news.title.toLowerCase().includes(term)
    );
  }

  goToAdminUser(userId: number): void {
    this.router.navigate(['/admin/users'], { queryParams: { editUserId: userId } });
  }
}
