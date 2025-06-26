import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminUsersComponent } from './admin-users.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { of } from 'rxjs';

describe('AdminUsersComponent', () => {
  let component: AdminUsersComponent;
  let fixture: ComponentFixture<AdminUsersComponent>;

beforeEach(async () => {
  await TestBed.configureTestingModule({
    imports: [AdminUsersComponent, HttpClientTestingModule],
    providers: [
      provideRouter([]),
      {
        provide: ActivatedRoute,
        useValue: {
          snapshot: { params: {}, data: {} },
          paramMap: of({ get: () => null }),
                queryParams: of({}), // <-- adaugă asta!

          // poți adăuga și alte mockuri dacă folosești mai mult din ActivatedRoute
        }
      }
    ]
  }).compileComponents();
  fixture = TestBed.createComponent(AdminUsersComponent);
  component = fixture.componentInstance;
  fixture.detectChanges();
});

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
