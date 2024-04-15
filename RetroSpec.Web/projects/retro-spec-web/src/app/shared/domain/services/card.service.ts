import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { CardDto } from '../dtos/card.dto';
import { CardCreateDto } from '../dtos/card-create.dto';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  private baseUrl = `${environment.apiUrl}/board`;
  private controllerUrl = '/card';

  constructor(private httpClient: HttpClient) { }

  public create(boardId: string, newCard: CardCreateDto): Observable<CardDto> {
    return this.httpClient.post<CardDto>(`${this.baseUrl}/${boardId}${this.controllerUrl}`, newCard);
  }

  public list(boardId: string): Observable<ReadonlyArray<CardDto>> {
    return this.httpClient.get<ReadonlyArray<CardDto>>(`${this.baseUrl}/${boardId}${this.controllerUrl}`);
  }
}
