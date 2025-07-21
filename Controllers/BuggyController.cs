using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace back_end.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly IRepository repo;

        public BuggyController(IRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<Person> GetNotFound()
        {
            return NotFound();
        }


        [HttpGet("server-error")]
        public async Task<ActionResult<string>> GetServerError()
        {

            var thing = await repo.getUserByIdAsync("-1");
            var thingToReturn = thing.ToString();
            return thingToReturn;
        }


        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }



    }
}
