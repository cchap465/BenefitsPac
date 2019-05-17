import { TestBed, inject } from '@angular/core/testing';

import { DependentsService } from './dependents.service';

describe('DependentsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DependentsService]
    });
  });

  it('should be created', inject([DependentsService], (service: DependentsService) => {
    expect(service).toBeTruthy();
  }));
});
