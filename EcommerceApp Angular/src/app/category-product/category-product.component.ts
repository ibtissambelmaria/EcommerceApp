import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailCategorieService } from '../detail-categorie.service';

@Component({
  selector: 'app-category-product',
  templateUrl: './category-product.component.html',
  styleUrls: ['./category-product.component.css']
})
export class CategoryProductComponent implements OnInit {
  categorie;

  constructor(
    private detailCategorieService:DetailCategorieService,
    private route:ActivatedRoute,) { }

  ngOnInit() {
    this.getDetailCategorie();
  }
  getDetailCategorie(){
    const categorieId=+this.route.params.subscribe(params=>{
      console.log(params);
      this.detailCategorieService.getById(params.id)
      .subscribe(
      data=>{this.categorie=data
      console.log(data)
    }
      )
      });
      
    }
  }