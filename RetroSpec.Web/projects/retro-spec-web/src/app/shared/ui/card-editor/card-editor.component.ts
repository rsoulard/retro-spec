import { Component, input } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-card-editor',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './card-editor.component.html',
  styleUrl: './card-editor.component.css'
})
export class CardEditorComponent {
  form = input.required<FormGroup>();
}
