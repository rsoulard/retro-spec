import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ButtonComponent, CardComponent, ColumnComponent, IconComponent } from 'retro-spec-components';
import { BoardDto } from '../../shared/domain/dtos/board.dto';
import { CardCreateDto } from '../../shared/domain/dtos/card-create.dto';
import { CardDto } from '../../shared/domain/dtos/card.dto';
import { BoardService } from '../../shared/domain/services/board.service';
import { CardService } from '../../shared/domain/services/card.service';
import { CardCreateComponent } from '../../shared/ui/card-create/card-create.component';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    CardComponent,
    ColumnComponent,
    ButtonComponent,
    IconComponent,
    CardCreateComponent
  ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css',
})
export class BoardComponent implements OnInit{

  protected board = signal<BoardDto | undefined>(undefined);
  protected cards = signal<ReadonlyArray<CardDto>>([]);
  protected newCard = signal<CardCreateDto | undefined>(undefined);

  constructor(private boardService: BoardService, private cardService: CardService, private route: ActivatedRoute) { }

  public ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')!;

    this.fetchBoard(id);
    this.fetchCards(id);
  }

  private fetchBoard(id: string) {
    this.boardService.get(id)
      .subscribe(response => {
        this.board.set(response);
      });
  }

  private fetchCards(boardId: string) {
    this.cardService.list(boardId)
      .subscribe(respnse => {
        this.cards.set(respnse);
      });
  }

  protected getCardsForColumn(columnId: number): ReadonlyArray<CardDto> {
    return this.cards().filter(card => card.columnId === columnId);
  }

  protected showNewCardInColumn(columnId: number) {
    this.newCard.set({ columnId, body: "" });
  }

  protected handleCardCreated(newCard: CardDto) {
    this.newCard.set(undefined);
    this.fetchCards(this.board()!.id);
  }
}
