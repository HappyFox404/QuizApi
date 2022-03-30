using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Services;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LobbyController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApiResponse> GetAll() => ApiResponse.ResponseOk(LobbyServices.GetAll());
        [HttpGet("{id}")]
        public ActionResult<ApiResponse> Get(int id) => ApiResponse.ResponseOk(LobbyServices.GetLobby(id));
        [HttpGet("{count}&{offset}")]
        public ActionResult<ApiResponse> Get(int count, int offset = 0) => ApiResponse.ResponseOk(LobbyServices.GetLobbies(count, offset));
    }
}