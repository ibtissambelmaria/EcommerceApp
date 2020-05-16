import { TestBed } from '@angular/core/testing';

import { DetailProduitService } from './detail-produit.service';

describe('DetailProduitService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DetailProduitService = TestBed.get(DetailProduitService);
    expect(service).toBeTruthy();
  });
});
