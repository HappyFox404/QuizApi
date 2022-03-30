using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    public class UtilController : Controller
    {
        QuizContext db;

        public UtilController(QuizContext context)
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