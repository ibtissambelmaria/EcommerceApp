using MyEcommerceAPP.Models;
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



namespace MyEcommerceAPP.Controllers
{
    public class ClientsController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/Clients
        public List<ClientViewModel> GetClient()
        {
            List<ClientViewModel> lcl = new List<ClientViewModel>();
            List<Client> cl = new List<Client>();
            cl = db.Client.ToList<Client>();
            foreach (var us in cl)
            {
                ClientViewModel user = new ClientViewModel();
                user.ID = us.ID;
                user.Nom = us.Nom;
                user.Prenom = us.Prenom;
                user.Email = us.Email;
                user.Password = us.Password;
                user.AdressFacturation = us.AdressFacturation;
                user.DateCreation = us.DateCreation;

                lcl.Add(user);


            }


            return lcl;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ID)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    

            using (ECOMMERCEDBEntities db = new ECOMMERCEDBEntities())
            {

                client.DateCreation = DateTime.Now;
                db.Client.Add(client);
                db.SaveChanges();

            }
            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);





        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ID == id) > 0;
        }
    }
}