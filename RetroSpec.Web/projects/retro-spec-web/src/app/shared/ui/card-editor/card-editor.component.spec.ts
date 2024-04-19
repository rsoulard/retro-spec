import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardEditorComponent } from './card-editor.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';

describe('CardEditorComponent', () => {
  let component: CardEditorComponent;
  let fixture: ComponentFixture<CardEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardEditorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardEditorComponent);
    component = fixture.componentInstance;
    fixture.componentRef.setInput('form', new FormGroup({
      body: new FormControl('', Validators.required)
    }));
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
