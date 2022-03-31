using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Services;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApiResponse> GetAll() => ApiResponse.ResponseOk(PlayerServices.Players);
        [HttpGet("{id}")]
        public ActionResult<ApiResponse> Get(int id) => ApiResponse.ResponseOk(PlayerServices.GetPlayer(id));
        [HttpPost]
        public ActionResult<ApiResponse> Create(PlayerTransfer player)
        {
            int idPlayer = PlayerServices.CreatePlayer(player.Name);
            return ApiResponse.ResponseOk(idPlayer);
        }
        [HttpPut("{id}")]
        public ActionResult<ApiResponse> Edit(int id, PlayerTransfer player)
        {
            if (PlayerServices.ChangeName(id, player.Name))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Player Not Found");
        }
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse> Delete(int id)
        {
            if (PlayerServices.DeletePlayer(id))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Player Not Found");
        }
        [HttpGet("Reneval/{id}")]
        public ActionResult<ApiResponse> Reneval(int id)
        {
            if (PlayerServices.RenevalActive(id))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Player Not Found");
        }
    }
}