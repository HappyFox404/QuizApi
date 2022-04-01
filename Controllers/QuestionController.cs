using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        QuizContext db;
        public QuestionController(QuizContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll() => ApiResponse.ResponseOk(await db.Questions.ToListAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> Get(string id) => ApiResponse.ResponseOk(await db.Questions.FirstOrDefaultAsync(q => q.Id == id));

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(QuestionTransfer question)
        {
            if (await db.Questions.FirstOrDefaultAsync(q => q.Text == question.Text && q.CategoryId == question.CategoryId) != null)
                return ApiResponse.ResponseServerError("Dublicate question");
            var newQuestion = new Question()
            {
                Text = question.Text,
                CategoryId = question.CategoryId
            };
            db.Add(newQuestion);
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk(newQuestion.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Edit(string id, QuestionTransfer question)
        {
            var editQuestion = await db.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (editQuestion == null)
                return ApiResponse.ResponseServerError("Question not found");
            editQuestion.Text = question.Text;
            editQuestion.CategoryId = question.CategoryId;
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(string id)
        {
            var deleteQuestion = await db.Questions.FirstOrDefaultAsync(q => q.Id == id);
            if (deleteQuestion == null)
                return ApiResponse.ResponseServerError("Question not found");
            db.Remove(deleteQuestion);
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }
    }
}