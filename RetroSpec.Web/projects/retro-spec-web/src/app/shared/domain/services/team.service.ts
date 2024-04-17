import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { TeamDto } from '../dtos/team.dto';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  private controllerUrl = '/team';

  constructor(private httpClient: HttpClient) { }

  public retrieve(id: string): Observable<TeamDto> {
    return this.httpClient.get<TeamDto>(`${environment.apiUrl}${this.controllerUrl}/${id}`);
  }
}
