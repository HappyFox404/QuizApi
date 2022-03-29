using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    public class Util : Controller
    {
        QuizContext db;

        public Util(QuizContext context)
        {
            db = context;
        }

        [Route("/rcreate")]
        public JsonResult RecreteDatabase()
        {
            return Json(ApiResponse.ResponseOk());
        }
    }
}