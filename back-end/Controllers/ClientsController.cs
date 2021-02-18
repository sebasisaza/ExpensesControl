using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using back_end.Commons.Entities;
using back_end.DataAccess;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<ResponsePage<List<Client>>> Get(int size, int page, string search)
        {
            var res = Clients.Get(size, page, search);
            return res;
        }
    }
}
