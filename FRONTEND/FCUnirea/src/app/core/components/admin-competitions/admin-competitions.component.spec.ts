import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCompetitionsComponent } from './admin-competitions.component';

describe('AdminCompetitionsComponent', () => {
  let component: AdminCompetitionsComponent;
  let fixture: ComponentFixture<AdminCompetitionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminCompetitionsComponent]
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
