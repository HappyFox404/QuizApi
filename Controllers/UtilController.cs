using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtilController : ControllerBase
    {
        QuizContext db;

        public UtilController(QuizContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("/rcreate")]
        public ActionResult<ApiResponse> RecreteDatabase()
        {
            return ApiResponse.ResponseOk();
        }
    }
}