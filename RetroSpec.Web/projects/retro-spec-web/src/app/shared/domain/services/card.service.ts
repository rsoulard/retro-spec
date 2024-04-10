import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { CardDto } from '../dtos/card.dto';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  private baseUrl = `${environment.apiUrl}/board`;
  private controllerUrl = '/card';

  constructor(private httpClient: HttpClient) { }

  public list(boardId: string): Observable<ReadonlyArray<CardDto>> {
    return this.httpClient.get<ReadonlyArray<CardDto>>(`${this.baseUrl}/${boardId}${this.controllerUrl}`);
  }
}
