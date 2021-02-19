using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using back_end.Commons.Entities;
using back_end.DataAccess;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public ActionResult<ResponsePage<List<Expense>>> Get(int size, int page)
        {
            var res = Expenses.Get(size, page);
            return res;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<ResponseItem<bool>> Create([FromBody] Expense expense)
        {
            var res = Expenses.Create(expense);
            return res;
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult<ResponseItem<bool>> Delete(int id)
        {
            var res = Expenses.Delete(id);
            return res;
        }

    }
}
