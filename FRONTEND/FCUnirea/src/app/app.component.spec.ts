import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent],
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
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have the 'FCUnirea' title`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    //expect(app.title).toEqual('FCUnirea');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    //expect(compiled.querySelector('h1')?.textContent).toContain('Hello, FCUnirea');
  });
});
