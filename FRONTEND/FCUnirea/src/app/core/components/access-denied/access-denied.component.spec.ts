import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessDeniedComponent } from './access-denied.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('AccessDeniedComponent', () => {
  let component: AccessDeniedComponent;
  let fixture: ComponentFixture<AccessDeniedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccessDeniedComponent, HttpClientTestingModule],
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
    
    fixture = TestBed.createComponent(AccessDeniedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
