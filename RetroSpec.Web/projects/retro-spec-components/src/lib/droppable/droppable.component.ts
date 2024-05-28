import { Component, input, output } from '@angular/core';

@Component({
  selector: 'retro-droppable',
  standalone: true,
  imports: [],
  templateUrl: './droppable.component.html',
  styleUrl: './droppable.component.css'
})
export class DroppableComponent {

  dataFormat = input.required<string>();

  onDragOver = output();
  onDrop = output<any>();

  protected handleDragOver(event: Event | DragEvent) {
    const dragEvent = event as DragEvent;
    dragEvent.preventDefault();

    this.onDragOver.emit();
  }

  protected handleDrop(event: Event | DragEvent) {
    const dragEvent = event as DragEvent;
    const eventData = dragEvent.dataTransfer?.getData(this.dataFormat());
    dragEvent.dataTransfer?.clearData();

    this.onDrop.emit(eventData);
  }
}
