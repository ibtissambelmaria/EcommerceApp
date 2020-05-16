
using MyEcommerceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEcommerceAPP.Models
{
    public class CategorieProduitModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Image { get; set; }
        public List<Produits> produit { get; set; }
    }

}