import { Component, OnInit, signal } from '@angular/core';
import { ButtonComponent, CardComponent, ColumnComponent, IconComponent } from 'retro-spec-components';
import { BoardService } from '../../shared/domain/services/board.service';
import { BoardDto } from '../../shared/domain/dtos/board.dto';
import { CardDto } from '../../shared/domain/dtos/card.dto';
import { CardService } from '../../shared/domain/services/card.service';
import { ActivatedRoute } from '@angular/router';

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

  constructor(private boardService: BoardService, private cardService: CardService, private route: ActivatedRoute) { }

  public ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')!;

    this.boardService.get(id)
      .subscribe(response => {
        this.board.set(response);
      });

    this.cardService.list(id)
      .subscribe(respnse => {
        this.cards.set(respnse);
      });
  }

  protected getCardsForColumn(columnId: number): ReadonlyArray<CardDto> {
    return this.cards().filter(card => card.columnId === columnId);
  }
}
