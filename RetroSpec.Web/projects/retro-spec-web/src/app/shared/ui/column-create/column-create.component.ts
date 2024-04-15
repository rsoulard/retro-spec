import { Component, input, output } from '@angular/core';
import { ColumnEditorComponent } from '../column-editor/column-editor.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ColumnService } from '../../domain/services/column.service';
import { ColumnCreateDto } from '../../domain/dtos/column-create.dto';
import { ColumnDto } from '../../domain/dtos/column.dto';
import { ButtonComponent } from 'retro-spec-components';

@Component({
  selector: 'app-column-create',
  standalone: true,
  imports: [
    ColumnEditorComponent,
    ButtonComponent
  ],
  templateUrl: './column-create.component.html',
  styleUrl: './column-create.component.css'
})
export class ColumnCreateComponent {

  protected formRoot!: FormGroup;

  boardId = input.required<string>();

  onCreate = output<ColumnDto>();
  onCancel = output();

  constructor(private formBuilder: FormBuilder, private columnService: ColumnService) {
    this.formRoot = formBuilder.group({
      name: ['', Validators.required]
    })
  }

  protected handleCreate() {
    const newColumn: ColumnCreateDto = {
      ...this.formRoot.value
    };

    console.log(newColumn);

    this.columnService.create(this.boardId(), newColumn)
      .subscribe(response => {
        this.onCreate.emit(response);
      });
  }
}
