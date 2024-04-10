import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { BoardDto } from '../dtos/board.dto';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  private controllerUrl = `${environment.apiUrl}/board`;

  constructor(private httpClient: HttpClient) { }

  public get(id: string): Observable<BoardDto> {
    return this.httpClient.get<BoardDto>(`${this.controllerUrl}/${id}`);
  }
}
