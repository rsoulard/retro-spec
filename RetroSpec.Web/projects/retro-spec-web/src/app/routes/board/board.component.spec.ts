import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BoardComponent } from './board.component';
import { of } from 'rxjs';
import { BoardService } from '../../shared/domain/services/board.service';
import { CardService } from '../../shared/domain/services/card.service';
import { provideRouter } from '@angular/router';
import { RouterTestingHarness } from '@angular/router/testing';

describe('BoardComponent', () => {
  let component: BoardComponent;
  let fixture: ComponentFixture<BoardComponent>;
  let boardRetrieveSpy;
  let cardListSpy;

  beforeEach(async () => {

    const boardService = jasmine.createSpyObj('BoardService', [
      'retrieve'
    ]);
    boardRetrieveSpy = boardService.retrieve.and.returnValue(of({
      id: '00000000-0000-0000-0000-000000000000',
      name: 'Test Board',
      columns: [
        {
          id: 0,
          name: 'Column 1'
        },
        {
          id: 1,
          name: 'Column 2'
        }
      ]
    }));

    const cardService = jasmine.createSpyObj('CardService', [
      'list'
    ]);
    cardListSpy = cardService.list.and.returnValue(of([
      {
        id: '00000000-0000-0000-0000-000000000001',
        columnId: 0,
        body: 'Card 1'
      },
      {
        id: '00000000-0000-0000-0000-000000000002',
        columnId: 1,
        body: 'Card 2'
      }
    ]));

    await TestBed.configureTestingModule({
      imports: [BoardComponent],
      providers: [
        provideRouter([{path: '**', component: BoardComponent}]),
        { provide: BoardService, useValue: boardService },
        { provide: CardService, useValue: cardService}
      ]
    })
    .compileComponents();

    const harness = await RouterTestingHarness.create();
    await harness.navigateByUrl('/', BoardComponent);
    harness.detectChanges();

    fixture = TestBed.createComponent(BoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
