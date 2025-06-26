import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { NewsService } from '../../services/news.service';
import { provideRouter } from '@angular/router';
import { of } from 'rxjs';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  const mockNewsService = {
    getAllNews: () => of([]),
    getNewsById: () => of({}),
    postComment: () => of({}),
    updateNews: () => of({}),
    addNews: () => of({}),
    deleteNews: () => of({}),
    deleteComment: () => of({})
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HomeComponent,
        FormsModule
      ],
      providers: [
        { provide: NewsService, useValue: mockNewsService },
        provideRouter([]) // <--- Asta înlocuiește RouterTestingModule
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
