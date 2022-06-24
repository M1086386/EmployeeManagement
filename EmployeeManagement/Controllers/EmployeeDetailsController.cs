using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Description;
using System;
using EmployeeManagement.Models;


namespace EmployeeManagement.Controllers
{
    //[EnableCors(origins:"https://localhost:4200",headers:"Access-Control-Allow-Origin",methods:"*")]
    public class EmployeeDetailsController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/EmployeeDetails
        public IQueryable<EmployeeDetailsTable> GetEmployeeDetailsTables()
        {
             Console.WriteLine("Fetch data");
            return db.EmployeeDetailsTables;
        }

        // GET: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetailsTable))]
        public IHttpActionResult GetEmployeeDetailsTable(string id)
        {
            EmployeeDetailsTable employeeDetailsTable = db.EmployeeDetailsTables.Find(id);
            if (employeeDetailsTable == null)
            {
               
                return NotFound();
            }

            return Ok(employeeDetailsTable);
        }

        public IHttpActionResult GetAllEmployeeDetails(string id)
        {
            EmployeeDetailsTable employeeDetailsTable = db.EmployeeDetailsTables.Find();
            if (employeeDetailsTable == null)
            {
                return NotFound();
            }

            return Ok(employeeDetailsTable);
        }

        // PUT: api/EmployeeDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeDetailsTable(string id, EmployeeDetailsTable employeeDetailsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeDetailsTable.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employeeDetailsTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsTableExists(id))
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

        // POST: api/EmployeeDetails
        [ResponseType(typeof(EmployeeDetailsTable))]
        public IHttpActionResult PostEmployeeDetailsTable(EmployeeDetailsTable employeeDetailsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetailsTables.Add(employeeDetailsTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailsTableExists(employeeDetailsTable.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            } 

            return CreatedAtRoute("DefaultApi", new { id = employeeDetailsTable.EmployeeId }, employeeDetailsTable);
        }

        // DELETE: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetailsTable))]
        public IHttpActionResult DeleteEmployeeDetailsTable(string id)
        {
            EmployeeDetailsTable employeeDetailsTable = db.EmployeeDetailsTables.Find(id);
            if (employeeDetailsTable == null)
            {
                return NotFound();
            }

            db.EmployeeDetailsTables.Remove(employeeDetailsTable);
            db.SaveChanges();

            return Ok(employeeDetailsTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailsTableExists(string id)
        {
            return db.EmployeeDetailsTables.Count(e => e.EmployeeId == id) > 0;
        }
    }
}