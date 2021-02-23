using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using back_end.Commons.Entities;
using back_end.DataAccess;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayCollectionsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<ResponsePage<List<DayCollection>>> Get(int size, int page, string search)
        {
            var res = DayCollections.Get(size, page, search);
            return res;
        }
    }
}
