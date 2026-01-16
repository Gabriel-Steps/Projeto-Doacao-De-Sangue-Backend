using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Application;
using ProjetoDoacaoDeSangue.Application.Middleware;
using ProjetoDoacaoDeSangue.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

#region Mediators
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(ApplicationAssemblyReference).Assembly
    )
);
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddInfra();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
