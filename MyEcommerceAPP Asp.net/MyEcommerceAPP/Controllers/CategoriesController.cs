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
    public class CategoriesController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/Categories
        public List<CategorieProduitModel> GetCategorie()
        {

            CategorieProduitModel cpm = null;
            var avm = db.Categorie.ToList();

            List<CategorieProduitModel> cvmm = new List<CategorieProduitModel>();
            foreach (var b in avm)
            {
                cpm = new CategorieProduitModel();
                cpm.ID = b.ID;
                cpm.Nom = b.Nom; 
                cpm.Image = b.Image;



                List<Produits> pd = new List<Produits>();
                foreach (var l in b.Produits)
                {
                    Produits prd = new Produits();
                    prd.ID = l.ID;
                    prd.Description = l.Description;
                    prd.Nom = l.Nom;
                    prd.Prix = l.Prix;
                    prd.Stock = l.Stock;
                    prd.Image = l.Image;
                    pd.Add(prd);
                }
                cpm.produit = pd;
                cvmm.Add(cpm);



            }
            return cvmm;
        }

        // GET: api/Categories/5
        //[Authorize]
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            CategorieProduitModel cpm = null;
            var avm = db.Categorie.ToList();

            List<CategorieProduitModel> cvmm = new List<CategorieProduitModel>();
            cpm = new CategorieProduitModel();
            cpm.Image = categorie.Image;
            cpm.ID = categorie.ID;
            cpm.Nom = categorie.Nom;
         
            List<Produits> pd = new List<Produits>();

            foreach (var l in categorie.Produits)
            {
                Produits prd = new Produits();

                prd.ID = l.ID;
                prd.Description = l.Description;
                prd.Nom = l.Nom;
                prd.Prix = l.Prix;

                prd.Stock = l.Stock;
                prd.Image = l.Image;
                pd.Add(prd);


            }
            cpm.produit = pd;
            cvmm.Add(cpm);

            return Ok(cvmm);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, Categorie categorie)
        {



            if (id != categorie.ID)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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


        // POST: api/Categories
        [ResponseType(typeof(Produits))]
        public IHttpActionResult PostCategorie(Produits produits)
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

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categorie.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categorie.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categorie.Count(e => e.ID == id) > 0;
        }
    }
}