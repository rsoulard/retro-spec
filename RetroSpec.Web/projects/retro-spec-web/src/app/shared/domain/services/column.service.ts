import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { ColumnCreateDto } from '../dtos/column-create.dto';
import { ColumnDto } from '../dtos/column.dto';

@Injectable({
  providedIn: 'root'
})
export class ColumnService {

  private baseUrl = `${environment.apiUrl}/board`;
  private controllerUrl = '/column';

  constructor(private httpClient: HttpClient) { }

  public create(boardId: string, newColumn: ColumnCreateDto) {
    return this.httpClient.post<ColumnDto>(`${this.baseUrl}/${boardId}${this.controllerUrl}`, newColumn);
  }
}
