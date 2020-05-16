import { HeaderService } from './../produit/header.service';
import { Component, OnInit } from '@angular/core';
import { Produit } from '../models/produit';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  produits: Produit[]=[];
  resultProduits: Produit[]=[];

  searchProduit='';
  constructor(private headerService: HeaderService, config: NgbRatingConfig) {
      config.max = 5;
      config.readonly = true;
     }
    ngOnInit() {
  this.getProduits();
  
    }
  getProduits(){
    this.headerService.findAll()
    .subscribe(produits=>{
      this.resultProduits=this.produits=produits
    })
  
  }
  searchProduits(){
    this.resultProduits=this.produits.filter((produit)=>produit.Nom.toLowerCase().includes(this.searchProduit.toLowerCase()))
  }

  }
  
  
  
  
  