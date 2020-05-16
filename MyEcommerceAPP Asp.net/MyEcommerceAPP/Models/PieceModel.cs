using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEcommerceAPP.Models
{
    public class PieceModel
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<System.DateTime> DateCommande { get; set; }
        public Nullable<int> NumCommande { get; set; }
        public Nullable<int> IdFacture { get; set; }
    }
}