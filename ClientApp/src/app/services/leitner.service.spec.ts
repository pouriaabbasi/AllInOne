import { TestBed } from '@angular/core/testing';

import { LeitnerService } from './leitner.service';

describe('LeitnerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LeitnerService = TestBed.get(LeitnerService);
    expect(service).toBeTruthy();
  });
});
