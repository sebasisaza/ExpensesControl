using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneralController : ControllerBase
    {
        [HttpGet]
        [Route("get/{date}")]
        public ActionResult<Commons.Entities.General> Get(string date)
        {
            var res = DataAccess.General.Get(date);
            return res;
        }
    }
}
