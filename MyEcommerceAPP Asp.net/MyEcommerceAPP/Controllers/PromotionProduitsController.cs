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
using MyEcommerceAPP.Models;

namespace MyEcommerceAPP.Controllers
{
    public class PromotionProduitsController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/PromotionProduits
        public IQueryable<PromotionProduit> GetPromotionProduit()
        {
            return db.PromotionProduit;
        }

        // GET: api/PromotionProduits/5
        [ResponseType(typeof(PromotionProduit))]
        public IHttpActionResult GetPromotionProduit(int id)
        {
            PromotionProduit promotionProduit = db.PromotionProduit.Find(id);
            if (promotionProduit == null)
            {
                return NotFound();
            }

            return Ok(promotionProduit);
        }

        // PUT: api/PromotionProduits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromotionProduit(int id, PromotionProduit promotionProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotionProduit.PromotionID)
            {
                return BadRequest();
            }

            db.Entry(promotionProduit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionProduitExists(id))
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

        // POST: api/PromotionProduits
        [ResponseType(typeof(PromotionProduit))]
        public IHttpActionResult PostPromotionProduit(PromotionProduit promotionProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PromotionProduit.Add(promotionProduit);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PromotionProduitExists(promotionProduit.PromotionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promotionProduit.PromotionID }, promotionProduit);
        }

        // DELETE: api/PromotionProduits/5
        [ResponseType(typeof(PromotionProduit))]
        public IHttpActionResult DeletePromotionProduit(int id)
        {
            PromotionProduit promotionProduit = db.PromotionProduit.Find(id);
            if (promotionProduit == null)
            {
                return NotFound();
            }

            db.PromotionProduit.Remove(promotionProduit);
            db.SaveChanges();

            return Ok(promotionProduit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotionProduitExists(int id)
        {
            return db.PromotionProduit.Count(e => e.PromotionID == id) > 0;
        }
    }
}