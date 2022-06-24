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
    public class LoginsController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/Logins
        public IQueryable<LoginTable> GetLoginTables()
        {
            return db.LoginTables;
        }

        // GET: api/Logins/5
        [ResponseType(typeof(LoginTable))]
        public IHttpActionResult GetLoginTable(int id)
        {
            LoginTable loginTable = db.LoginTables.Find(id);
            if (loginTable == null)
            {
                return NotFound();
            }

            return Ok(loginTable);
        }

        // PUT: api/Logins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoginTable(int id, LoginTable loginTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginTable.LoginId)
            {
                return BadRequest();
            }

            db.Entry(loginTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginTableExists(id))
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

        // POST: api/Logins
        [ResponseType(typeof(LoginTable))]
        public IHttpActionResult PostLoginTable(LoginTable loginTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoginTables.Add(loginTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoginTableExists(loginTable.LoginId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loginTable.LoginId }, loginTable);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(LoginTable))]
        public IHttpActionResult DeleteLoginTable(int id)
        {
            LoginTable loginTable = db.LoginTables.Find(id);
            if (loginTable == null)
            {
                return NotFound();
            }

            db.LoginTables.Remove(loginTable);
            db.SaveChanges();

            return Ok(loginTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginTableExists(int id)
        {
            return db.LoginTables.Count(e => e.LoginId == id) > 0;
        }
    }
}