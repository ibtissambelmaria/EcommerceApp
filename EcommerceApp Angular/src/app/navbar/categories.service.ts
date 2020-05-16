import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { categorie } from './categorie';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http:HttpClient) { }
  findAll(){
    return this.http.get<categorie[]>("https://localhost:44385/api/categories");
  }
}
