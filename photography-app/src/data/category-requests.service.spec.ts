import { TestBed } from '@angular/core/testing';

import { CategoryRequestsService } from './category-requests.service';

describe('CategoryRequestsService', () => {
  let service: CategoryRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
