import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamDetailsComponent } from './team-details.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ActivatedRoute } from '@angular/router';

describe('TeamDetailsComponent', () => {
  let component: TeamDetailsComponent;
  let fixture: ComponentFixture<TeamDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeamDetailsComponent, HttpClientTestingModule],
          providers: [
{
  provide: ActivatedRoute,
  useValue: {
    snapshot: {
      paramMap: {
        get: (key: string) => {
          if (key === 'id') return '1'; // sau ce id vrei pentru test
          return null;
        }
      },
      params: {},
      data: {}
    }
  }
}

    ]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TeamDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
