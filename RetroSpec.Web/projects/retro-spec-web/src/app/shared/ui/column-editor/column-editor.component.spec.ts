import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColumnEditorComponent } from './column-editor.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';

describe('ColumnEditorComponent', () => {
  let component: ColumnEditorComponent;
  let fixture: ComponentFixture<ColumnEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ColumnEditorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ColumnEditorComponent);
    component = fixture.componentInstance;
    fixture.componentRef.setInput('form', new FormGroup({
      name: new FormControl('', Validators.required)
    }));
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
