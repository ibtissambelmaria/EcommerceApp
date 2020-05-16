
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Produit } from '../models/produit';


@Injectable({
  providedIn: 'root'
})
export class HeaderService {

  constructor(private http: HttpClient ) { }
  findAll(){
   return this.http.get<Produit[]>('https://localhost:44385/api/produits');
  }
}
