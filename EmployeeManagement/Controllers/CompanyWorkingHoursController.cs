using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using EmployeeManagement.Models;


namespace EmployeeManagement.Controllers
{


    //[EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class CompanyWorkingHoursController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/CompanyWorkingHours
        public IQueryable<CompanyWorkingHour> GetCompanyWorkingHours()
        {
            return db.CompanyWorkingHours;
        }

        // GET: api/CompanyWorkingHours/5
        [ResponseType(typeof(CompanyWorkingHour))]
        public IHttpActionResult GetCompanyWorkingHour(int id)
        {
            CompanyWorkingHour companyWorkingHour = db.CompanyWorkingHours.Find(id);
            if (companyWorkingHour == null)
            {
                return NotFound();
            }

            return Ok(companyWorkingHour);
        }

        // PUT: api/CompanyWorkingHours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyWorkingHour(int id, CompanyWorkingHour companyWorkingHour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyWorkingHour.CompanyWorkingHourId)
            {
                return BadRequest();
            }

            db.Entry(companyWorkingHour).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyWorkingHourExists(id))
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

        // POST: api/CompanyWorkingHours
        [ResponseType(typeof(CompanyWorkingHour))]
        public IHttpActionResult PostCompanyWorkingHour(CompanyWorkingHour companyWorkingHour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyWorkingHours.Add(companyWorkingHour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyWorkingHourExists(companyWorkingHour.CompanyWorkingHourId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyWorkingHour.CompanyWorkingHourId }, companyWorkingHour);
        }

        // DELETE: api/CompanyWorkingHours/5
        [ResponseType(typeof(CompanyWorkingHour))]
        public IHttpActionResult DeleteCompanyWorkingHour(int id)
        {
            CompanyWorkingHour companyWorkingHour = db.CompanyWorkingHours.Find(id);
            if (companyWorkingHour == null)
            {
                return NotFound();
            }

            db.CompanyWorkingHours.Remove(companyWorkingHour);
            db.SaveChanges();

            return Ok(companyWorkingHour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyWorkingHourExists(int id)
        {
            return db.CompanyWorkingHours.Count(e => e.CompanyWorkingHourId == id) > 0;
        }
    }
}