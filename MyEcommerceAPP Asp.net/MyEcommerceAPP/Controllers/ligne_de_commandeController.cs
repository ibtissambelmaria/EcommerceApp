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
    public class ligne_de_commandeController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/ligne_de_commande
        public IQueryable<ligne_de_commande> Getligne_de_commande()
        {
            return db.ligne_de_commande;
        }

        // GET: api/ligne_de_commande/5
        [ResponseType(typeof(ligne_de_commande))]
        public IHttpActionResult Getligne_de_commande(int id)
        {
            ligne_de_commande ligne_de_commande = db.ligne_de_commande.Find(id);
            if (ligne_de_commande == null)
            {
                return NotFound();
            }

            return Ok(ligne_de_commande);
        }

        // PUT: api/ligne_de_commande/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putligne_de_commande(int id, ligne_de_commande ligne_de_commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ligne_de_commande.Qauntity)
            {
                return BadRequest();
            }

            db.Entry(ligne_de_commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ligne_de_commandeExists(id))
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

        // POST: api/ligne_de_commande
        [ResponseType(typeof(ligne_de_commande))]
        public IHttpActionResult Postligne_de_commande(ligne_de_commande ligne_de_commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ligne_de_commande.Add(ligne_de_commande);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ligne_de_commandeExists(ligne_de_commande.Qauntity))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ligne_de_commande.Qauntity }, ligne_de_commande);
        }

        // DELETE: api/ligne_de_commande/5
        [ResponseType(typeof(ligne_de_commande))]
        public IHttpActionResult Deleteligne_de_commande(int id)
        {
            ligne_de_commande ligne_de_commande = db.ligne_de_commande.Find(id);
            if (ligne_de_commande == null)
            {
                return NotFound();
            }

            db.ligne_de_commande.Remove(ligne_de_commande);
            db.SaveChanges();

            return Ok(ligne_de_commande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ligne_de_commandeExists(int id)
        {
            return db.ligne_de_commande.Count(e => e.Qauntity == id) > 0;
        }
    }
}