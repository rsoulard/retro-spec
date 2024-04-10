import { HttpClient } from '@angular/common/http';
import { Injectable, Signal, signal } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { BoardDto } from '../dtos/board.dto';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  private controllerUrl = `${environment.apiUrl}/board`;

  public board = signal<BoardDto | undefined>(undefined);

  constructor(private httpClient: HttpClient) { }

  public get(id: string): void {
    this.httpClient.get<BoardDto>(`${this.controllerUrl}/96c081f2-f98c-4bd5-98b6-310edd44c7b7`)
      .subscribe(result => {
        this.board.set(result);
      });
  }
}
