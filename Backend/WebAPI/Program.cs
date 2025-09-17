var builder = WebApplication.CreateBuilder(args);

// ��������� ������� �� http://localhost:5000
builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ����� Swagger ������� ������, ���������� ��� �������
app.UseSwagger();
app.UseSwaggerUI();

// ������� ��� ��������������� ��� ������, ���� ������ �������� ������ �� http
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// �������������� ������ / �� Swagger UI
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.Run();