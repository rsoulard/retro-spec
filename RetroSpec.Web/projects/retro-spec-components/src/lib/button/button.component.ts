import { Component, input, signal } from '@angular/core';

@Component({
  selector: 'retro-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
  title = input<string>();
  onClick = input<(event: MouseEvent | null) => void>(() => { });
}
