import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ButtonComponent, CardComponent, DraggableComponent, DroppableComponent, IconComponent } from 'retro-spec-components';
import { BoardDto } from '../../shared/domain/dtos/board.dto';
import { CardDto } from '../../shared/domain/dtos/card.dto';
import { ColumnDto } from '../../shared/domain/dtos/column.dto';
import { BoardService } from '../../shared/domain/services/board.service';
import { CardService } from '../../shared/domain/services/card.service';
import { CardCreateComponent } from '../../shared/ui/card-create/card-create.component';
import { ColumnCreateComponent } from '../../shared/ui/column-create/column-create.component';

@Component({
  selector: 'app-board',
  standalone: true,
  imports: [
    CardComponent,
    ButtonComponent,
    IconComponent,
    CardCreateComponent,
    ColumnCreateComponent,
    DraggableComponent,
    DroppableComponent
  ],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css',
})
export class BoardComponent implements OnInit {

  protected board = signal<BoardDto | undefined>(undefined);
  protected cards = signal<ReadonlyArray<CardDto>>([]);
  protected newCardColumnId = signal<number | undefined>(undefined);
  protected showNewColumnForm = signal<boolean>(false);

  constructor(private boardService: BoardService, private cardService: CardService, private route: ActivatedRoute) { }

  public ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')!;

    this.fetchBoard(id);
    this.fetchCards(id);
  }

  private fetchBoard(id: string) {
    this.boardService.retrieve(id)
      .subscribe(response => {
        this.board.set(response);
      });
  }

  private fetchCards(boardId: string) {
    this.cardService.list(boardId)
      .subscribe(response => {
        this.cards.set(response);
      });
  }

  protected getCardsForColumn(columnId: number): ReadonlyArray<CardDto> {
    return this.cards().filter(card => card.columnId === columnId);
  }

  protected handleNewCard(columnId: number) {
    this.newCardColumnId.set(columnId);
  }

  protected handleCardCreated(newCard: CardDto) {
    this.newCardColumnId.set(undefined);
    this.cards.set([...this.cards(), newCard]);
  }

  protected handleCardCreateCancelled() {
    this.newCardColumnId.set(undefined);
  }

  protected handleNewColumn() {
    this.showNewColumnForm.set(true);
  }

  protected handleColumnCreated(newColumn: ColumnDto) {
    this.board.set({ ...this.board()!, columns: [...this.board()!.columns, newColumn] })
    this.showNewColumnForm.set(false);
  }

  protected handleColumnCreateCancelled() {
    this.showNewColumnForm.set(false);
  }

  protected handleCardDropped(columnId: number, cardId: any) {
    cardId = cardId as string;

    this.cards()!
      .find(card => card.id === cardId)!
      .columnId = columnId;

    this.cardService.move(cardId, { columnId })
      .subscribe(() => {
        this.fetchCards(this.board()!.id);
      });
  }
}
