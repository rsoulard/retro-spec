import { Component, input } from '@angular/core';

@Component({
  selector: 'retro-textarea-input',
  standalone: true,
  imports: [],
  templateUrl: './textarea-input.component.html',
  styleUrl: './textarea-input.component.css'
})
export class TextareaInputComponent {
  placeholder = input.required<string>();
}
