using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        QuizContext db;
        public AnswerController(QuizContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll() => ApiResponse.ResponseOk(await db.Answers.ToListAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> Get(string id) => ApiResponse.ResponseOk(await db.Answers.FirstOrDefaultAsync(a => a.Id == id));

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(AnswerTransfer answer)
        {
            if (await db.Answers.FirstOrDefaultAsync(a => a.Text == answer.Text && a.QuestionId == answer.QuestionId) != null)
                return ApiResponse.ResponseServerError("Dublicate Answer");
            var newAnswer = new Answer()
            {
                Text = answer.Text,
                QuestionId = answer.QuestionId
            };
            db.Add(newAnswer);
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk(newAnswer.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Edit(string id, AnswerTransfer answer)
        {
            var editAnswer = await db.Answers.FirstOrDefaultAsync(a => a.Id == id);
            if (editAnswer == null)
                return ApiResponse.ResponseServerError("Answer not found");
            editAnswer.Text = answer.Text;
            editAnswer.QuestionId = answer.QuestionId;
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(string id)
        {
            var deleteAnswer = await db.Answers.FirstOrDefaultAsync(a => a.Id == id);
            if (deleteAnswer == null)
                return ApiResponse.ResponseServerError("Answer not found");
            db.Remove(deleteAnswer);
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }
    }
}