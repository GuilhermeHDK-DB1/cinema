using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using Cinema.Dados.Contextos;
using Cinema.Dados.Repositorio;
using Cinema.Dominio.Common;
using Cinema.Dominio.Services.Manipuladores;
using Cinema.Dominio.Services;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Consultas.Generos;
using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Web.Filters;
using Cinema.Dominio.Common.Notifications;
using Cinema.Dominio.Consultas.Salas;
using Cinema.Dominio.Dtos.Salas;
using Cinema.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policy => policy.AddPolicy("corspolicy", build =>
{
    //requisições de origens específicas
    //build.WithOrigins("http://localhost:3000", "http://localhost:5158").AllowAnyMethod().AllowAnyHeader();

    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration["ConnectionString"]));
builder.Services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddScoped(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));
builder.Services.AddScoped(typeof(IGeneroConsulta), typeof(GeneroConsulta));
builder.Services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
builder.Services.AddScoped(typeof(IFilmeConsulta), typeof(FilmeConsulta));
builder.Services.AddScoped(typeof(ISalaRepositorio), typeof(SalaRepositorio));
builder.Services.AddScoped(typeof(ISalaConsulta), typeof(SalaConsulta));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped<ManipuladorDeGenero>();
builder.Services.AddScoped<ManipuladorDeFilme>();
builder.Services.AddScoped<ManipuladorDeSala>();

builder.Services.AddValidators();

builder.Services.AddScoped<NotificationContext>();
builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>())
.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();