import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColumnCreateComponent } from './column-create.component';

describe('ColumnCreateComponent', () => {
  let component: ColumnCreateComponent;
  let fixture: ComponentFixture<ColumnCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ColumnCreateComponent]
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
