import { Component, input } from '@angular/core';
import { IconComponent } from '../icon/icon.component';

@Component({
  selector: 'retro-button',
  standalone: true,
  imports: [
    IconComponent
  ],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
  iconName = input<string | null>(null);
  title = input<string>();
  onClick = input<(event: MouseEvent | null) => void>(() => { });
}
