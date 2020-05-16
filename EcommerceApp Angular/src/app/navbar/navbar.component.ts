import { categorie } from './categorie';
import { Component, OnInit } from '@angular/core';
import { CategoriesService } from './categories.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  categories:categorie[]=[];
    constructor(private categoriesService :CategoriesService) { }
  
    ngOnInit() {
   this.getCategories();
    }
  getCategories(){
    this.categoriesService.findAll()
    
    .subscribe(categories=>this.categories=categories)
  }
  }
  
