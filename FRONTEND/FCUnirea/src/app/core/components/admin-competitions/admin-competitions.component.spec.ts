import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCompetitionsComponent } from './admin-competitions.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AdminCompetitionsComponent', () => {
  let component: AdminCompetitionsComponent;
  let fixture: ComponentFixture<AdminCompetitionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminCompetitionsComponent, HttpClientTestingModule]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminCompetitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
