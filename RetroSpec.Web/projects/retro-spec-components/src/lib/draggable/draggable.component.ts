import { Component, input } from '@angular/core';

@Component({
  selector: 'retro-draggable',
  standalone: true,
  imports: [],
  templateUrl: './draggable.component.html',
  styleUrl: './draggable.component.css'
})
export class DraggableComponent {

  dataFormat = input.required<string>();
  data = input.required<any>();

  protected handleDragStart(event: Event | DragEvent) {
    const dragEvent = event as DragEvent;
    dragEvent?.dataTransfer?.setData(this.dataFormat(), this.data());
  }
}
