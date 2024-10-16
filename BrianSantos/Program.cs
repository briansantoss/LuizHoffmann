using BrianSantos.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/funcionario/cadastrar", ([FromBody] Funcionario funcionarioNovo, [FromServices] AppDataContext contexto) =>
{
    contexto.Funcionarios.Add(funcionarioNovo);
    contexto.SaveChanges();
    return Results.Created("", funcionarioNovo);
});

app.MapGet("/funcionario/listar", ([FromServices] AppDataContext contexto) =>
{
    List<Funcionario> funcionarios  = contexto.Funcionarios.ToList();

    if (funcionarios.Any()) 
    {
        return Results.Ok(funcionarios);
    }
    return Results.NotFound("Não há funcionários cadastrados em nosso sistema.");
});

app.Run();
