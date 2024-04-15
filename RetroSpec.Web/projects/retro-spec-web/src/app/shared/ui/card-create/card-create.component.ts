import { Component, input, output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ButtonComponent } from 'retro-spec-components';
import { CardCreateDto } from '../../domain/dtos/card-create.dto';
import { CardDto } from '../../domain/dtos/card.dto';
import { CardService } from '../../domain/services/card.service';
import { CardEditorComponent } from '../card-editor/card-editor.component';

@Component({
  selector: 'app-card-create',
  standalone: true,
  imports: [
    CardEditorComponent,
    ButtonComponent
  ],
  templateUrl: './card-create.component.html',
  styleUrl: './card-create.component.css'
})
export class CardCreateComponent {
  protected formRoot!: FormGroup;

  boardId = input.required<string>();
  columnId = input.required<number>();

  onCreate = output<CardDto>();

  constructor(private formBuilder: FormBuilder, private cardService: CardService) {
    this.formRoot = formBuilder.group({
      body: ['', Validators.required]
    });
  }

  handleCreate() {
    const newCard: CardCreateDto = {
      columnId: this.columnId(),
      ...this.formRoot.value
    }

    console.log(newCard);

    this.cardService.create(this.boardId(), newCard)
      .subscribe(response => {
        this.onCreate.emit(response);
      });
  }
}
