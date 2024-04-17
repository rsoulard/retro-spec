import { TestBed, inject } from '@angular/core/testing';
import { ColumnService } from './column.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../../../../environments/environment';

describe('ColumnService', () => {
  let service: ColumnService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(ColumnService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call create endpoint', inject(
    [HttpTestingController, ColumnService],
    (mockHttp: HttpTestingController, columnService: ColumnService) => {
      const mockColumn = {
        id: 0,
        name: 'test'
      };

      columnService.create('00000000-0000-0000-0000-000000000000', {
        name: 'test'
      })
        .subscribe(response => {
          expect(response).toEqual(mockColumn);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/board/00000000-0000-0000-0000-000000000000/column`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('POST');
      mockRequest.flush(mockColumn);

      mockHttp.verify();
    }
  ))
});
