using Cinema.Dados.Contextos;
using Cinema.Dados.Repositorio;
using Cinema.Dominio.Common;
using Cinema.Dominio.Services.Handlers;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using Cinema.Dominio.Consultas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddScoped(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));
builder.Services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IGeneroConsulta), typeof(GeneroConsulta));
builder.Services.AddScoped<ManipuladorDeGenero>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    await next.Invoke();
    string method = context.Request.Method;
    var allowedMethodsToCommit = new string[] { "POST", "PUT", "DELETE" };
    if (allowedMethodsToCommit.Contains(method))
    {
        var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
        await unitOfWork.Commit();
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();