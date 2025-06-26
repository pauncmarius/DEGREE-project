import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketingComponent } from './ticketing.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('TicketingComponent', () => {
  let component: TicketingComponent;
  let fixture: ComponentFixture<TicketingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TicketingComponent, HttpClientTestingModule],
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
    
    fixture = TestBed.createComponent(TicketingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
