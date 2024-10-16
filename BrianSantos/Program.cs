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
    /*ATUALIZAR SALARIO BRUTO, IMPOSTO DE RENDA, INSS, FGTS, LIQUIDO*/
    Folha folhaNova = new Folha(folha.valor, folha.quantidade);
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



app.Run();
