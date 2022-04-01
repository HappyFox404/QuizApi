using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        QuizContext db;
        public CategoryController(QuizContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll() => ApiResponse.ResponseOk(await db.Categories.ToListAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> Get(int id) => ApiResponse.ResponseOk(await db.Categories.FirstOrDefaultAsync(c => c.Id == id));

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(CategoryTransfer category)
        {
            if (await db.Categories.FirstOrDefaultAsync(c => c.Name == category.Name) != null)
                return ApiResponse.ResponseServerError("Dublicate category name");
            db.Categories.Add(new Category() { Name = category.Name });
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Edit(int id, CategoryTransfer category)
        {
            var categoryEdit = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryEdit == null)
                return ApiResponse.ResponseServerError("Category not found");
            categoryEdit.Name = category.Name;
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var categoryDelete = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryDelete == null)
                return ApiResponse.ResponseServerError("Category not found");
            db.Categories.Remove(categoryDelete);
            await db.SaveChangesAsync();
            return ApiResponse.ResponseOk();
        }
    }
}