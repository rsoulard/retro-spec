import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed, inject } from '@angular/core/testing';
import { environment } from '../../../../environments/environment';
import { CardService } from './card.service';

describe('CardService', () => {
  let service: CardService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(CardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call create endpoint', inject(
    [HttpTestingController, CardService],
    (mockHttp: HttpTestingController, cardService: CardService) => {
      const mockCard = {
        id: '00000000-0000-0000-0000-000000000000',
        columnId: 0,
        body: 'test'
      };

      cardService.create('00000000-0000-0000-0000-000000000000', {
        columnId: 0,
        body: 'test'
      })
        .subscribe(response => {
          expect(response).toEqual(mockCard);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/board/00000000-0000-0000-0000-000000000000/card`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('POST');
      mockRequest.flush(mockCard);

      mockHttp.verify();
    }
  ));

  it('should call list endoint', inject(
    [HttpTestingController, CardService],
    (mockHttp: HttpTestingController, cardService: CardService) => {
      const mockCards = [
        {
          id: '00000000-0000-0000-0000-000000000001',
          columnId: 0,
          body: 'test 1'
        },
        {
          id: '00000000-0000-0000-0000-000000000002',
          columnId: 0,
          body: 'test 2'
        },
        {
          id: '00000000-0000-0000-0000-000000000003',
          columnId: 1,
          body: 'test 3'
        }
      ];

      cardService.list('00000000-0000-0000-0000-000000000000')
        .subscribe(response => {
          expect(response).toEqual(mockCards);
        });

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/board/00000000-0000-0000-0000-000000000000/card`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('GET');
      mockRequest.flush(mockCards);
    }
  ));

  it('should call move endoint', inject(
    [HttpTestingController, CardService],
    (mockHttp: HttpTestingController, cardService: CardService) => {
      cardService.move('00000000-0000-0000-0000-000000000000', {
        columnId: 1
      })
        .subscribe();

      const mockRequest = mockHttp.expectOne(`${environment.apiUrl}/card/00000000-0000-0000-0000-000000000000/move`);
      expect(mockRequest.cancelled).toBeFalsy();
      expect(mockRequest.request.method).toEqual('POST');
      mockRequest.flush("");
    }
  ));
});
