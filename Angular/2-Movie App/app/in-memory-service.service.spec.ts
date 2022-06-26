import { TestBed } from '@angular/core/testing';

import { InMemoryServiceService } from './in-memory-service.service';

describe('InMemoryServiceService', () => {
  let service: InMemoryServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InMemoryServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
