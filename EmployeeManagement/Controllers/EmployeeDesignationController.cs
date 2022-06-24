using System;
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

    // [EnableCors(origins: "http://localhost:4200/", headers: "Access-Control-Allow-Origin", methods: "*")]
    public class EmployeeDesignationController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/EmployeeDesignation
        public IQueryable<EmployeeDesignationTable> GetEmployeeDesignationTables()
        {
            return db.EmployeeDesignationTables;
        }

        // GET: api/EmployeeDesignation/5
        [ResponseType(typeof(EmployeeDesignationTable))]
        public IHttpActionResult GetEmployeeDesignationTable(int id)
        {
            EmployeeDesignationTable employeeDesignationTable = db.EmployeeDesignationTables.Find(id);
            if (employeeDesignationTable == null)
            {
                return NotFound();
            }

            return Ok(employeeDesignationTable);
        }

        // PUT: api/EmployeeDesignation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeDesignationTable(int id, EmployeeDesignationTable employeeDesignationTable)
        {
            Console.WriteLine("Fetch data");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeDesignationTable.DesignationId)
            {
                return BadRequest();
            }

            db.Entry(employeeDesignationTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDesignationTableExists(id))
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

        // POST: api/EmployeeDesignation
        [ResponseType(typeof(EmployeeDesignationTable))]
        public IHttpActionResult PostEmployeeDesignationTable(EmployeeDesignationTable employeeDesignationTable)
        {
            Console.WriteLine("Fetch data");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDesignationTables.Add(employeeDesignationTable);

            try
            {
                 db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDesignationTableExists(employeeDesignationTable.DesignationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeDesignationTable.DesignationId }, employeeDesignationTable);
        }

        // DELETE: api/EmployeeDesignation/5
        [ResponseType(typeof(EmployeeDesignationTable))]
        public IHttpActionResult DeleteEmployeeDesignationTable(int id)
        {
            EmployeeDesignationTable employeeDesignationTable = db.EmployeeDesignationTables.Find(id);
            if (employeeDesignationTable == null)
            {
                return NotFound();
            }

            db.EmployeeDesignationTables.Remove(employeeDesignationTable);
            db.SaveChanges();

            return Ok(employeeDesignationTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDesignationTableExists(int id)
        {
            return db.EmployeeDesignationTables.Count(e => e.DesignationId == id) > 0;
        }
    }
}