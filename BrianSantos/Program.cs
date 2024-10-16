using BrianSantos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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

app.MapPost("/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext contexto) =>
{
    Funcionario? funcionarioAssociado = contexto.Funcionarios.Find(folha.FuncionarioId);
    if(funcionarioAssociado == null){
        return Results.NotFound("Erro, Funcionario não existe!");
    }
    contexto.Folhas.Add(folha);
    contexto.SaveChanges();
    return Results.Created("", folha);

});


app.MapGet("/folha/listar", ([FromServices] AppDataContext contexto) =>
{
    List<Folha> folhas = contexto.Folhas.ToList();
    return Results.Ok(folhas);


});

app.Run();
