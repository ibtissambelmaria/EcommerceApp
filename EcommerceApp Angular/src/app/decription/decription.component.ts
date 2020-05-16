import { Component, OnInit} from '@angular/core';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute } from '@angular/router';
import { DetailProduitService } from '../detail-produit.service';


@Component({
  selector: 'app-decription',
  templateUrl: './decription.component.html',
  styleUrls: ['./decription.component.css']
})
export class DecriptionComponent implements OnInit {
  detail;

 
  constructor(
    private detailProduitService:DetailProduitService,
    private route:ActivatedRoute,
    config: NgbRatingConfig) {
    // customize default values of ratings used by this component tree
    config.max = 5;
    config.readonly = true;
  }
  ngOnInit() {
    this.getDetailProduit();
  }
  getDetailProduit(){
    const detailId=+this.route.params.subscribe(params=>{
      console.log(params);
      
      this.detailProduitService.getById(params.id)
    .subscribe(
    data=>{this.detail=data
    console.log(data)
  }
   
    )
    });
    
  }
}