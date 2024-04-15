import { Component, input } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-column-editor',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './column-editor.component.html',
  styleUrl: './column-editor.component.css'
})
export class ColumnEditorComponent {
  form = input.required<FormGroup>();
}
