using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Cinema.Dominio.Common;
using Cinema.Web.Filters;
using Cinema.Dominio.Common.Notifications;
using Cinema.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddScoped<NotificationContext>();
builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>())
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
builder.Services.AddCors(policy => policy.AddPolicy("corspolicy", build =>
    { build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

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