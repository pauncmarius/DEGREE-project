import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminGamesComponent } from './admin-games.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('AdminGamesComponent', () => {
  let component: AdminGamesComponent;
  let fixture: ComponentFixture<AdminGamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminGamesComponent, HttpClientTestingModule],
          providers: [
      {
        provide: ActivatedRoute,
        useValue: {
          snapshot: { params: {}, data: {} },   // minimul necesar, adaptează după caz
          paramMap: of({ get: () => null }),
          // orice proprietăți ai nevoie în testul tău
        }
      }
    ]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminGamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
