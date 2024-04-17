import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';
import { environment } from '../../../../environments/environment';
import { BoardService } from './board.service';

describe('BoardService', () => {
  let service: BoardService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(BoardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call retrieve endpoint', inject(
    [HttpTestingController, BoardService],
    (mockHttp: HttpTestingController, boardService: BoardService) => {
      const mockBoard = {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Test',
        columns: [
          {
            id: 0,
            name: 'Column 1'
          },
          {
            id: 1,
            name: 'Column 2'
          }
        ]
      };

      boardService.retrieve('00000000-0000-0000-0000-000000000000')
        .subscribe(response => {
          expect(response).toEqual(mockBoard);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/board/00000000-0000-0000-0000-000000000000`);

      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('GET');
      mockRequest.flush(mockBoard);

      mockHttp.verify();
    }
  ));

  it('should call list endpoint', inject(
    [HttpTestingController, BoardService],
    (mockHttp: HttpTestingController, boardService: BoardService) => {
      const mockBoards = [
        {
          id: '00000000-0000-0000-0000-000000000001',
          name: 'Test 1'
        },
        {
          id: '00000000-0000-0000-0000-000000000002',
          name: 'Test 2'
        }
      ];

      boardService.list('00000000-0000-0000-0000-000000000000')
        .subscribe(response => {
          expect(response).toEqual(mockBoards);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/team/00000000-0000-0000-0000-000000000000/board`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('GET');
      mockRequest.flush(mockBoards);

      mockHttp.verify();
    }
  ));
});
