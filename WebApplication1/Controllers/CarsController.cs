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
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Cars
        [ResponseType(typeof(List<CarsModel>))]
        public IHttpActionResult GetCars()
        {
            return Ok(db.Cars.ToList().ConvertAll(x => new CarsModel(x)));
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Cars))]
        public IHttpActionResult GetCars(int id)
        {
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCars(int id, Cars cars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cars.id_cars)
            {
                return BadRequest();
            }

            db.Entry(cars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Cars))]
        public IHttpActionResult PostCars(Cars cars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(cars);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cars.id_cars }, cars);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Cars))]
        public IHttpActionResult DeleteCars(int id)
        {
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return NotFound();
            }

            db.Cars.Remove(cars);
            db.SaveChanges();

            return Ok(cars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarsExists(int id)
        {
            return db.Cars.Count(e => e.id_cars == id) > 0;
        }
    }
}