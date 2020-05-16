import { TestBed } from '@angular/core/testing';

import { DetailCategorieService } from './detail-categorie.service';

describe('DetailCategorieService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DetailCategorieService = TestBed.get(DetailCategorieService);
    expect(service).toBeTruthy();
  });
});
