﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using back_end.Commons.Entities;
using back_end.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace back_end.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DayCollectionsController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<ResponseItem<List<DayCollection>>> Get()
        {
            var res = DayCollections.Get();
            return res;
        }
    }
}
