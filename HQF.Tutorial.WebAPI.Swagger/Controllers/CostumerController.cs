using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HQF.Tutorial.WebAPI.Swagger.Models;
using HQF.Tutorial.WebAPI.Swagger.Repositories;

namespace HQF.Tutorial.WebAPI.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        /// <summary>
        /// Gets customers.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="offset">The offset.</param>
        /// <remarks>Gets a paged list of customers. Page number and offset must be specified.</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ResponseType(typeof(IEnumerable<Customer>))]
        public IHttpActionResult Get(int page, int offset)
        {
            return Ok(CustomerRepository.GetCustomers(page, offset));
        }

        /// <summary>
        /// Get customer
        /// </summary>
        /// <param name="email">The email.</param>
        /// <remarks>
        /// Get signle customer by providing email
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Get(string email)
        {
            var customer = CustomerRepository.GetCustomers(email);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <remarks>Insert new customer</remarks>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>        
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CustomerRepository.GetCustomers().Any(x => x.Email.Equals(customer.Email)))
            {
                return BadRequest("Customer with the same email already exists");
            }

            CustomerRepository.AddCustomer(customer);

            string uri = Url.Link("DefaultApi", new { controller = "Customers", email = customer.Email });

            return Created(uri, customer);
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="email">Customer email</param>
        /// <remarks>Delete existing customer</remarks>        
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        public HttpResponseMessage Delete(string email)
        {
            var customer = CustomerRepository.GetCustomers().Where(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            CustomerRepository.RemoveCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
