import { Component, input } from '@angular/core';

@Component({
  selector: 'retro-icon',
  standalone: true,
  imports: [],
  templateUrl: './icon.component.html',
  styleUrl: './icon.component.css'
})
export class IconComponent {
  name = input.required<string>();
}
