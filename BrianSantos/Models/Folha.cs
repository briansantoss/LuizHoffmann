namespace BrianSantos.Models;

public class Folha{
    public int FolhaId { get; set; }
    public float valor {get; set;}
    public int quantidade {get; set;}
    public int mes{get; set;}
    public int ano {get; set;}
    public float salarioBruto {get; set;}
    public float impostoIrrf {get; set;}
    public float impostoInns {get; set;}
    public float impostoFgts {get; set;}
    public float salarioLiquido {get; set;}

    public int FuncionarioId {get; set;}
    public Funcionario Funcionario {get; set;} = null!;

}