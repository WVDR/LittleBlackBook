using IreneAdler.Models;
using IreneAdler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IreneAdler.Controllers
{
    public class ContactApiController : ApiController
    {
        private IDataAccessRepository<CONTACT, Guid> _repository;
        //Inject the DataAccessRepository using Construction Injection 
        public ContactApiController(IDataAccessRepository<CONTACT, Guid> Repository)
        {
            _repository = Repository;
        }
        // GET api/<controller>
        public IEnumerable<CONTACT> Get()
        {
            return _repository.Get();
        }

        // GET api/<controller>/5
        [ResponseType(typeof(CONTACT))]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        // POST api/<controller>
        [ResponseType(typeof(CONTACT))]
        public IHttpActionResult Post(CONTACT contact)
        {
            _repository.Post(contact);
            return Ok(contact);
        }

        // PUT api/<controller>/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Guid id, CONTACT contact)
        {
            _repository.Put(id, contact);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}