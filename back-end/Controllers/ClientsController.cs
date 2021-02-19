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

        [HttpPost]
        [Route("create")]
        public ActionResult<ResponseItem<bool>> Create([FromBody]Client client)
        {
            var res = Clients.Create(client);
            return res;
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult<ResponseItem<Client>> GetById(int id)
        {
            var res = Clients.GetById(id);
            return res;
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<ResponseItem<bool>> Update([FromBody] Client client)
        {
            var res = Clients.Update(client);
            return res;
        }
    }
}
