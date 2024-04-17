import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { BoardDto } from '../dtos/board.dto';
import { BoardListDto } from '../dtos/board-list.dto';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  private controllerUrl = '/board';

  constructor(private httpClient: HttpClient) { }

  public retrieve(id: string): Observable<BoardDto> {
    return this.httpClient.get<BoardDto>(`${environment.apiUrl}${this.controllerUrl}/${id}`);
  }

  public list(teamId: string): Observable<ReadonlyArray<BoardListDto>> {
    return this.httpClient.get<ReadonlyArray<BoardListDto>>(`${environment.apiUrl}/team/${teamId}${this.controllerUrl}`);
  }
}
