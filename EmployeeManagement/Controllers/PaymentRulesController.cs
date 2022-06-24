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
    public class PaymentRulesController : ApiController
    {
        private EmployeeManagementDBEntities db = new EmployeeManagementDBEntities();

        // GET: api/PaymentRules
        public IQueryable<PaymentRule> GetPaymentRules()
        {
            return db.PaymentRules;
        }

        // GET: api/PaymentRules/5
        [ResponseType(typeof(PaymentRule))]
        public IHttpActionResult GetPaymentRule(int id)
        {
            PaymentRule paymentRule = db.PaymentRules.Find(id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            return Ok(paymentRule);
        }

        // PUT: api/PaymentRules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentRule(int id, PaymentRule paymentRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentRule.DocumentId)
            {
                return BadRequest();
            }

            db.Entry(paymentRule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRuleExists(id))
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

        // POST: api/PaymentRules
        [ResponseType(typeof(PaymentRule))]
        public IHttpActionResult PostPaymentRule(PaymentRule paymentRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentRules.Add(paymentRule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentRuleExists(paymentRule.DocumentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentRule.DocumentId }, paymentRule);
        }

        // DELETE: api/PaymentRules/5
        [ResponseType(typeof(PaymentRule))]
        public IHttpActionResult DeletePaymentRule(int id)
        {
            PaymentRule paymentRule = db.PaymentRules.Find(id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            db.PaymentRules.Remove(paymentRule);
            db.SaveChanges();

            return Ok(paymentRule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentRuleExists(int id)
        {
            return db.PaymentRules.Count(e => e.DocumentId == id) > 0;
        }
    }
}