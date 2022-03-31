using Microsoft.EntityFrameworkCore;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

PlayerServices.Init();
LobbyServices.Init();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<QuizContext>(options => options.UseMySQL(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
