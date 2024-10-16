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
    if(folhas.Any()){
        return Results.Ok(folhas);
    }
    
    return Results.NotFound("Erro, nenhuma folha foi encotrado!");

});

app.MapGet("/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano, [FromServices] AppDataContext contexto) =>
{
    Folha? folha = contexto.Folhas.FirstOrDefault(f => (f.Funcionario.Cpf == cpf && f.mes == mes && f.ano == ano));

    if (folha == null)
    {
        return Results.NotFound($"Não existe nenhuma folha com {cpf}, {mes}, {ano}.");
    }
    return Results.Ok(folha);
});

app.Run();
