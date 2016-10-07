using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using training_sample.Data;
using training_sample.Models;

namespace training_sample.Controllers
{
    public class CustomerController : ApiController
    {
        // Could use DI or simialr if wanted
        private readonly IRepository<Customer> _customerRepository = new CouchbaseRepository<Customer>();

        public HttpResponseMessage Get()
        {
            var customers = _customerRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        public HttpResponseMessage Get(string id)
        {
            var customer = _customerRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        public HttpResponseMessage Put([FromBody] Customer customer, string id)
        {
            var result = _customerRepository.Update(id, customer);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, customer);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        public HttpResponseMessage Post([FromBody] Customer customer, string id)
        {
            var result = _customerRepository.Create(id, customer);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, customer);
            }

            return Request.CreateResponse(HttpStatusCode.Created, customer);
        }

        public HttpResponseMessage Delete(string id)
        {
            var customer = _customerRepository.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}
