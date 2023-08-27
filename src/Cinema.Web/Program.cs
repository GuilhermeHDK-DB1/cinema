using Cinema.Dados.Contextos;
using Cinema.Dados.Repositorio;
using Cinema.Dominio.Common;
using Cinema.Dominio.Services.Manipuladores;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Cinema.Dominio.Dtos.Generos;
using FluentValidation.AspNetCore;
using Cinema.Dominio.Consultas.Generos;
using Cinema.Dominio.Consultas.Filmes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
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
builder.Services.AddScoped(typeof(IFilmeConsulta), typeof(FilmeConsulta));
builder.Services.AddScoped<ManipuladorDeGenero>();
builder.Services.AddScoped<ManipuladorDeFilme>();


builder.Services.AddScoped(typeof(IValidator<CadastrarGeneroCommand>), typeof(CadastrarGeneroValidator));
builder.Services.AddScoped(typeof(IValidator<AtualizarGeneroCommand>), typeof(AtualizarGeneroValidator));
builder.Services.AddScoped(typeof(IValidator<ExcluirGeneroQuery>), typeof(ExcluirGeneroValidator));

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
        unitOfWork.Commit();
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();