import { Component, input } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextareaInputComponent } from 'retro-spec-components';

@Component({
  selector: 'app-card-editor',
  standalone: true,
  imports: [
    TextareaInputComponent,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './card-editor.component.html',
  styleUrl: './card-editor.component.css'
})
export class CardEditorComponent {
  form = input.required<FormGroup>();
}
