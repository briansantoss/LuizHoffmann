using Microsoft.EntityFrameworkCore;

namespace BrianSantos.Models;

[Index("Cpf", IsUnique = true)]
public class Funcionario
{
    public int FuncionarioId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    ICollection<Folha>? Folhas;
}