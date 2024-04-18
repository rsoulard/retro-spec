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
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
