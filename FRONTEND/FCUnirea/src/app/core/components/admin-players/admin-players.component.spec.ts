import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminPlayersComponent } from './admin-players.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { of } from 'rxjs';

describe('AdminPlayersComponent', () => {
  let component: AdminPlayersComponent;
  let fixture: ComponentFixture<AdminPlayersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        AdminPlayersComponent, // <--- componenta ta standalone!
        HttpClientTestingModule // <--- pentru serviciile care fac http!
      ],
      providers: [
        provideRouter([]), // <--- înlocuiește RouterTestingModule
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: { params: {}, data: {} },
            queryParams: of({}), // folosit în ngOnInit
            paramMap: of({ get: () => null }),
          }
        },
        // Dacă ai nevoie, poți adăuga și mock pentru PlayersService și TeamService,
        // altfel, cu HttpClientTestingModule, serviciile injectate vor funcționa cu http mock.
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(AdminPlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
