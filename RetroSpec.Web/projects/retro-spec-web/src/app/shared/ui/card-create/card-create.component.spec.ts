import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { CardService } from '../../domain/services/card.service';
import { CardCreateComponent } from './card-create.component';

describe('CardCreateComponent', () => {
  let component: CardCreateComponent;
  let fixture: ComponentFixture<CardCreateComponent>;
  let cardServiceSpy: any;

  beforeEach(async () => {
    cardServiceSpy = jasmine.createSpyObj('CardService', [
      'create'
    ]);
    cardServiceSpy.create.and.returnValue(of({
      id: '00000000-0000-0000-0000-000000000000',
      columnId: 0,
      body: 'Test Card'
    }));

    await TestBed.configureTestingModule({
      imports: [
        CardCreateComponent,
        ReactiveFormsModule
      ],
      providers: [
        { provide: CardService, useValue: cardServiceSpy }
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CardCreateComponent);
    component = fixture.componentInstance;
    fixture.componentRef.setInput('boardId', '00000000-0000-0000-0000-000000000000');
    fixture.componentRef.setInput('columnId', 0);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call create when clicked', () => {
    const saveButtonDebug = fixture.debugElement.query(element => 
      element.name === 'retro-button' && element.attributes['title'] === 'save'
    );
    saveButtonDebug.triggerEventHandler('onClick');

    fixture.detectChanges();

    expect(cardServiceSpy.create.calls.count())
      .withContext('card service create was called once')
      .toBe(1);
  });
});
