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

   // [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class LeaveRequestsController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/LeaveRequests
        public IQueryable<RequestLeave> GetRequestLeaves()
        {
            return db.RequestLeaves;
        }

        // GET: api/LeaveRequests/5
        [ResponseType(typeof(RequestLeave))]
        public IHttpActionResult GetRequestLeave(int id)
        {
            RequestLeave requestLeave = db.RequestLeaves.Find(id);
            if (requestLeave == null)
            {
                return NotFound();
            }

            return Ok(requestLeave);
        }

        // PUT: api/LeaveRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestLeave(int id, RequestLeave requestLeave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestLeave.LeaveId)
            {
                return BadRequest();
            }

            db.Entry(requestLeave).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestLeaveExists(id))
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

        // POST: api/LeaveRequests
        [ResponseType(typeof(RequestLeave))]
        public IHttpActionResult PostRequestLeave(RequestLeave requestLeave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestLeaves.Add(requestLeave);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RequestLeaveExists(requestLeave.LeaveId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = requestLeave.LeaveId }, requestLeave);
        }

        // DELETE: api/LeaveRequests/5
        [ResponseType(typeof(RequestLeave))]
        public IHttpActionResult DeleteRequestLeave(int id)
        {
            RequestLeave requestLeave = db.RequestLeaves.Find(id);
            if (requestLeave == null)
            {
                return NotFound();
            }

            db.RequestLeaves.Remove(requestLeave);
            db.SaveChanges();

            return Ok(requestLeave);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestLeaveExists(int id)
        {
            return db.RequestLeaves.Count(e => e.LeaveId == id) > 0;
        }
    }
}