using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
    services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TestDB"));
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
}

app.Run();