using System.Collections.Generic;
using back_end.DataAccess;
using Microsoft.AspNetCore.Mvc;
using back_end.Commons.Entities;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsControllers : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<ResponsePage<List<Client>>> Get()
        {
            var res = Clients.Get();
            return res;
        }
    }
}
