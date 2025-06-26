import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingComponent } from './landing.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('LandingComponent', () => {
  let component: LandingComponent;
  let fixture: ComponentFixture<LandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandingComponent, HttpClientTestingModule],
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
    
    fixture = TestBed.createComponent(LandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
