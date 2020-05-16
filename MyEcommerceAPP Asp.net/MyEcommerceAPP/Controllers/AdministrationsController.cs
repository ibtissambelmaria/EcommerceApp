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
    [Authorize(Roles = "Administrator")]
    public class AdministrationsController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/Administrations
        public IQueryable<Administration> GetAdministration()
        {
            return db.Administration;
        }

        // GET: api/Administrations/5
        [ResponseType(typeof(Administration))]
        public IHttpActionResult GetAdministration(int id)
        {
            Administration administration = db.Administration.Find(id);
            if (administration == null)
            {
                return NotFound();
            }

            return Ok(administration);
        }

        // PUT: api/Administrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministration(int id, Administration administration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administration.ID)
            {
                return BadRequest();
            }

            db.Entry(administration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrationExists(id))
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

        // POST: api/Administrations
        [ResponseType(typeof(Administration))]
        public IHttpActionResult PostAdministration(Administration administration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administration.Add(administration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administration.ID }, administration);
        }

        // DELETE: api/Administrations/5
        [ResponseType(typeof(Administration))]
        public IHttpActionResult DeleteAdministration(int id)
        {
            Administration administration = db.Administration.Find(id);
            if (administration == null)
            {
                return NotFound();
            }

            db.Administration.Remove(administration);
            db.SaveChanges();

            return Ok(administration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrationExists(int id)
        {
            return db.Administration.Count(e => e.ID == id) > 0;
        }
    }
}