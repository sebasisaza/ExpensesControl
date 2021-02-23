using back_end.Commons.Entities;
using back_end.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientPaymentsController : ControllerBase
    {
        [HttpGet]
        [Route("getByIdClient/{id_client}")]
        public ActionResult<ResponseItem<ClientDetail>> Get(int id_client)
        {
            var res = ClientsPayments.GetByClient(id_client);
            return res;
        }
    }
}
