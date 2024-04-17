import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';
import { environment } from '../../../../environments/environment';
import { TeamService } from './team.service';

describe('TeamService', () => {
  let service: TeamService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(TeamService);
  });

  it('should be created', () => {
      expect(service).toBeTruthy();
  });

  it('should call retrieve endpoint', inject(
    [HttpTestingController, TeamService],
    (mockHttp: HttpTestingController, teamService: TeamService) => {
      const mockTeam = {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Test'
      };

      teamService.retrieve('00000000-0000-0000-0000-000000000000')
        .subscribe(response => {
          expect(response).toEqual(mockTeam);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/team/00000000-0000-0000-0000-000000000000`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('GET');
      mockRequest.flush(mockTeam);

      mockHttp.verify();
    }
  ))
});
