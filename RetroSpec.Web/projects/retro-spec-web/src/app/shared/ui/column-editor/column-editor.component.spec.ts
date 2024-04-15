import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColumnEditorComponent } from './column-editor.component';

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
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
