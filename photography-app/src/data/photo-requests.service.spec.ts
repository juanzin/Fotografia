import { TestBed } from '@angular/core/testing';

import { PhotoRequestsService } from './photo-requests.service';

describe('PhotoRequestsService', () => {
  let service: PhotoRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PhotoRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
