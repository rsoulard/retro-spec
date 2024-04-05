import { Component, input } from '@angular/core';

@Component({
  selector: 'retro-column',
  standalone: true,
  imports: [],
  templateUrl: './column.component.html',
  styleUrl: './column.component.css'
})
export class ColumnComponent {
  title = input.required<string>();
}
