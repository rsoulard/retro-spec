import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { ColumnCreateDto } from '../dtos/column-create.dto';
import { ColumnDto } from '../dtos/column.dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColumnService {

  private controllerUrl = '/column';

  constructor(private httpClient: HttpClient) { }

  public create(boardId: string, newColumn: ColumnCreateDto) : Observable<ColumnDto> {
    return this.httpClient.post<ColumnDto>(`${environment.apiUrl}/board/${boardId}${this.controllerUrl}`, newColumn);
  }
}
