using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private IRepository _repository;
        public PollController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Poll
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _repository.GetQuestions();
        }

        //// GET: api/Poll/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Poll
        [HttpPost]
        [Produces("application/json")]
        public JsonResult Post([FromBody] Poll value)
        {
            return  new JsonResult("OK");
        }

        //// PUT: api/Poll/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
