import { Component, OnInit } from '@angular/core';
import { ButtonComponent, CardComponent, ColumnComponent, IconComponent } from 'retro-spec-components';
import { BoardService } from '../../shared/domain/services/board.service';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    CardComponent,
    ColumnComponent,
    ButtonComponent,
    IconComponent
  ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css',
})
export class BoardComponent implements OnInit{

  constructor(protected boardService: BoardService) { }

  public ngOnInit() {
    this.boardService.get('Test');
  }
}
