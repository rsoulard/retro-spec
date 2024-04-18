import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { RouterTestingHarness } from '@angular/router/testing';
import { of } from 'rxjs';
import { TeamService } from '../../shared/domain/services/team.service';
import { TeamComponent } from './team.component';

describe('TeamComponent', () => {
  let component: TeamComponent;
  let fixture: ComponentFixture<TeamComponent>;
  let teamRetrieveSpy;

  beforeEach(async () => {
    const teamService = jasmine.createSpyObj('TeamService', [
      'retrieve'
    ]);
    teamRetrieveSpy = teamService.retrieve.and.returnValue(of({
      id: '00000000-0000-0000-0000-000000000000',
      name: 'Test Team'
    }));

    await TestBed.configureTestingModule({
      imports: [TeamComponent],
      providers: [
        provideRouter([{ path: '**', component: TeamComponent }]),
        { provide: TeamService, useValue: teamService }
      ]
    })
      .compileComponents();

    const harness = await RouterTestingHarness.create();
    await harness.navigateByUrl('/', TeamComponent);

    fixture = TestBed.createComponent(TeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have team name', () => {
    const teamHTML: HTMLElement = fixture.nativeElement as HTMLElement;

    const header = teamHTML.querySelector('h1')!;
    expect(header.textContent).toContain('Test Team');
  });
});
