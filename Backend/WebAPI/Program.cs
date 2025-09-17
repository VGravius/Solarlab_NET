var builder = WebApplication.CreateBuilder(args);

// Настройка запуска на http://localhost:5000
builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Чтобы Swagger работал всегда, подключаем без условия
app.UseSwagger();
app.UseSwaggerUI();

// Уберите или закомментируйте эту строку, если хотите работать строго по http
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Перенаправляем корень / на Swagger UI
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.Run();