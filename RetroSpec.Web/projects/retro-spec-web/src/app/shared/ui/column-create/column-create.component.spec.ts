import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { ColumnService } from '../../domain/services/column.service';
import { ColumnCreateComponent } from './column-create.component';

describe('ColumnCreateComponent', () => {
  let component: ColumnCreateComponent;
  let fixture: ComponentFixture<ColumnCreateComponent>;
  let columnServiceSpy: any;

  beforeEach(async () => {
    columnServiceSpy = jasmine.createSpyObj('ColumnService', [
      'create'
    ]);
    columnServiceSpy.create.and.returnValue(of({
      id: 0,
      name: 'Test Column'
    }));

    await TestBed.configureTestingModule({
      imports: [
        ColumnCreateComponent,
        ReactiveFormsModule
      ],
      providers: [
        { provide: ColumnService, useValue: columnServiceSpy }
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ColumnCreateComponent);
    component = fixture.componentInstance;
    fixture.componentRef.setInput('boardId', '00000000-0000-0000-0000-000000000000');
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

    expect(columnServiceSpy.create.calls.count())
      .withContext('column service create was called once')
      .toBe(1);
  });
});
