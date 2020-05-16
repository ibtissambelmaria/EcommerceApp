using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EcommerceWebApi.Models;
using MyEcommerceAPP.Models;

namespace EcommerceWebApi.Controllers
{
    public class ProduitsController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();
       
       // GET: api/Produits
       //  [Authorize]
      //[Route("Produit")]
        public List<DetailProduit> GetProduits()
        {
            List<DetailProduit> ldp = new List<DetailProduit>();
            List<Produits> lp = new List<Produits>();
            lp = db.Produits.ToList();
            foreach (var p in lp)
            {
                DetailProduit dp = new DetailProduit();
                dp.ID = p.ID;
                dp.Nom = p.Nom;
                dp.Image = p.Image;
                dp.Prix = p.Prix;
                dp.Stock = p.Stock;       
                dp.Description = p.Description;
                ldp.Add(dp);
            }
            return ldp;
        }

        //[Authorize]
        // GET: api/Produits/5
   // [Route("DetailProduit/{{id}}")]
        [ResponseType(typeof(Produits))]
        public IHttpActionResult GetProduits(int id)
        {
            var promotionProduit = db.PromotionProduit.Where(p => p.ProduitsID == id).ToList();
            if (promotionProduit == null)
            {
                return NotFound();
            }
            DetailProduit dp = new DetailProduit();
            double? tp = 0;
            foreach (var pp in promotionProduit)
            {
                if (pp.DateDebut < DateTime.Now && pp.DateExpidite > DateTime.Now)
                {
                   
                    tp += pp.Promotion.ValeurPromotion;
                }

            }
         
            var produit = db.Produits.Where(p => p.ID == id).FirstOrDefault();
        
            dp.ID = produit.ID;
            dp.Nom = produit.Nom;
            dp.Prix = produit.Prix;
            dp.Image = produit.Image;
            dp.Description = produit.Description;
         
            dp.Stock= produit.Stock;

            
            dp.PrixPromo = dp.Prix - (dp.Prix * tp / 100);

            return Ok(dp);
        }

        // PUT: api/Produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduits(int id, Produits produits)
        {

            if (id != produits.ID)
            {
                return BadRequest();
            }

            db.Entry(produits).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produits
        [ResponseType(typeof(Produits))]
        public IHttpActionResult PostProduits(Produits produits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ECOMMERCEDBEntities db = new ECOMMERCEDBEntities())
            {

                db.Produits.Add(produits);
                db.SaveChanges();

            }


            return CreatedAtRoute("DefaultApi", new { id = produits.ID }, produits);
        }

        // DELETE: api/Produits/5
        [ResponseType(typeof(Produits))]
        public IHttpActionResult DeleteProduits(int id)
        {
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return NotFound();
            }

            db.Produits.Remove(produits);
            db.SaveChanges();

            return Ok(produits);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProduitsExists(int id)
        {
            return db.Produits.Count(e => e.ID == id) > 0;
        }
    }
}