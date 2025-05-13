import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStadiumsComponent } from './admin-stadiums.component';

describe('AdminStadiumsComponent', () => {
  let component: AdminStadiumsComponent;
  let fixture: ComponentFixture<AdminStadiumsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminStadiumsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminStadiumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
