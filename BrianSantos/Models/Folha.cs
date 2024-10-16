namespace BrianSantos.Models;

public class Folha{
    public int FolhaId { get; set; }
    public float valor {get; set;}
    public float quantidade {get; set;}
    public int mes{get; set;}
    public int ano {get; set;}
    public float salarioBruto {get; set;}
    public float impostoIrrf {get; set;}
    public float impostoInns {get; set;}
    public float impostoFgts {get; set;}
    public float salarioLiquido {get; set;}

    public int FuncionarioId {get; set;}
    public Funcionario Funcionario {get; set;} = null!;


    public Folha(float valor, float quantidade){
        this.valor = valor;
        this.quantidade = quantidade;
        this.salarioBruto = this.valor * this.quantidade;

        if(this.salarioBruto < 1903.98){
            this.impostoIrrf = 0;
        } 
        if(this.salarioBruto > 1903.98 && this.salarioBruto < 2826.65 ){

            this.impostoIrrf = this.salarioBruto * (float) 0.07 - (float) 142.80;
        }

        if(this.salarioBruto > 2826.66 && this.salarioBruto < 3751.05 ){

            this.impostoIrrf = this.salarioBruto * (float) 0.15 - (float) 354.80;
        }

        if(this.salarioBruto > 3751.06 && this.salarioBruto < 4664.68){

            this.impostoIrrf = this.salarioBruto * (float) 0.225 - (float) 636.13;
        }

        if(this.salarioBruto > 4664.68){
            this.impostoIrrf = this.salarioBruto * (float) 0.275 - (float) 869.36;
        } 

        /* NSS */
        if(this.salarioBruto <= 1693.72){
            this.impostoInns = this.salarioBruto * (float) 0.92;
        } 

        if(this.salarioBruto > 1693.73 && this.salarioBruto < 2822.90 ){

            this.impostoInns = this.salarioBruto * (float) 0.91;
        }

        if(this.salarioBruto > 2822.90 && this.salarioBruto < 5645.80 ){

            this.impostoInns = this.salarioBruto * (float) 0.89;
        }

         if(this.salarioBruto > 5645.81){
            this.impostoInns = this.salarioBruto - (float) 621.03;
        } 

        this.impostoFgts = this.salarioBruto * (float) 0.08;

        this.salarioLiquido = this.salarioBruto - this.impostoIrrf - this.impostoInns;


    }

}

