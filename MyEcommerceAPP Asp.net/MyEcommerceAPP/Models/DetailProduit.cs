using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebApi.Models
{
    public class DetailProduit
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Nom { get; set; }
        public Nullable<double> Prix { get; set; }
        public Nullable<double> PrixPromo { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Image { get; set; }
    }
}