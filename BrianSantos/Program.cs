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

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext contexto) =>
{
    contexto.Add(folha);
    contexto.SaveChanges();
    return Results.Created("", folha);

});




app.Run();
