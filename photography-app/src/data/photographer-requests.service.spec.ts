import { TestBed } from '@angular/core/testing';

import { PhotographerRequestsService } from './photographer-requests.service';

describe('PhotographerRequestsService', () => {
  let service: PhotographerRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PhotographerRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
