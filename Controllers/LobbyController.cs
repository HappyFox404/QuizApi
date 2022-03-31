using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Services;

/*
    TODO:
    CodeReview Create
    Add Method Append Player
*/

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
        [HttpGet("Offset")]
        public ActionResult<ApiResponse> GetOffset(int count, int offset = 0) => ApiResponse.ResponseOk(LobbyServices.GetLobbies(count, offset));
        [HttpPost]
        public ActionResult<ApiResponse> Create(int id, LobbyTransfer lobby)
        {
            int idLobby = LobbyServices.CreateLobby(lobby.Name, PlayerServices.GetPlayer(id));
            return ApiResponse.ResponseOk(idLobby);
        }
        [HttpPut("{id}")]
        public ActionResult<ApiResponse> Edit(int id, LobbyTransfer lobby)
        {
            if (LobbyServices.ChangeName(id, lobby.Name))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Lobby Not Found");
        }
        [HttpDelete("{id}")]
        public ActionResult<ApiResponse> Delete(int id)
        {
            if (LobbyServices.CloseLobby(id))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Lobby Not Found");
        }
        [HttpGet("Reneval/{id}")]
        public ActionResult<ApiResponse> Reneval(int id)
        {
            if (LobbyServices.RenevalActive(id))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Lobby Not Found");
        }
        [HttpGet("Start/{id}")]
        public ActionResult<ApiResponse> Start(int id)
        {
            if (LobbyServices.StartGame(id))
                return ApiResponse.ResponseOk();
            return ApiResponse.ResponseServerError("Lobby Not Found");
        }
    }
}