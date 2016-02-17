using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GSB.EnterpriseCenter.WebApi.Models;

namespace GSB.EnterpriseCenter.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return new Product[] {};
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return new Product();
        }

        // POST: api/Product
        public void Post([FromBody]Product value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
