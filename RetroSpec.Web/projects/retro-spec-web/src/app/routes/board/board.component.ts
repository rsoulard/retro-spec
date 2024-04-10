import { Component, OnInit, signal } from '@angular/core';
import { ButtonComponent, CardComponent, ColumnComponent, IconComponent } from 'retro-spec-components';
import { BoardService } from '../../shared/domain/services/board.service';
import { BoardDto } from '../../shared/domain/dtos/board.dto';
import { CardDto } from '../../shared/domain/dtos/card.dto';
import { CardService } from '../../shared/domain/services/card.service';

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

  protected board = signal<BoardDto | undefined>(undefined);
  protected cards = signal <ReadonlyArray<CardDto>>([]);

  constructor(private boardService: BoardService, private cardService: CardService) { }

  public ngOnInit() {
    this.boardService.get('96c081f2-f98c-4bd5-98b6-310edd44c7b7')
      .subscribe(response => {
        this.board.set(response);
      });

    this.cardService.list('96c081f2-f98c-4bd5-98b6-310edd44c7b7')
      .subscribe(respnse => {
        this.cards.set(respnse);
      });
  }

  protected getCardsForColumn(columnId: number): ReadonlyArray<CardDto> {
    return this.cards().filter(card => card.columnId === columnId);
  }
}
