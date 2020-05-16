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

namespace EcommerceWepApiAuth.Controllers
{
    public class PiecesController : ApiController
    {
        private ECOMMERCEDBEntities db = new ECOMMERCEDBEntities();

        // GET: api/Pieces
        public IQueryable<Piece> GetPiece()
        {
            return db.Piece;
        }

        // GET: api/Pieces/5
        [ResponseType(typeof(Piece))]
        public IHttpActionResult GetPiece(int id)
        {
            Piece piece = db.Piece.Find(id);
            if (piece == null)
            {
                return NotFound();
            }

            return Ok(piece);
        }

        // PUT: api/Pieces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPiece(int id, Piece piece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piece.ID)
            {
                return BadRequest();
            }

            db.Entry(piece).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceExists(id))
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

        // POST: api/Pieces
        [ResponseType(typeof(Piece))]
        public IHttpActionResult PostPiece(Piece piece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ECOMMERCEDBEntities db = new ECOMMERCEDBEntities())
              
            {
                piece.DateCommande = DateTime.Now;
                db.Piece.Add(piece);
                db.SaveChanges();
            }


            return CreatedAtRoute("DefaultApi", new { id = piece.ID }, piece);
        }

        // DELETE: api/Pieces/5
        [ResponseType(typeof(Piece))]
        public IHttpActionResult DeletePiece(int id)
        {
            Piece piece = db.Piece.Find(id);
            if (piece == null)
            {
                return NotFound();
            }

            db.Piece.Remove(piece);
            db.SaveChanges();

            return Ok(piece);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PieceExists(int id)
        {
            return db.Piece.Count(e => e.ID == id) > 0;
        }
    }
}