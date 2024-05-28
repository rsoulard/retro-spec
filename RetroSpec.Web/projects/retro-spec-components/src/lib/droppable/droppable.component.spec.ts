import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DroppableComponent } from './droppable.component';

describe('DroppableComponent', () => {
  let component: DroppableComponent;
  let fixture: ComponentFixture<DroppableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DroppableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DroppableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
