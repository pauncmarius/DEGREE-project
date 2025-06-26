import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { AdminTeamsComponent } from './admin-teams.component';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('AdminTeamsComponent', () => {
  let component: AdminTeamsComponent;
  let fixture: ComponentFixture<AdminTeamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminTeamsComponent, HttpClientTestingModule],
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
    
    fixture = TestBed.createComponent(AdminTeamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
