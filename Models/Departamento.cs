using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GestaoEscolar.Models;

public class Departamento
{
    [Key]
    public long DepartamentoId { get; set; }
    public string Nome { get; set; }
    
    [ForeignKey("Instituicao")]
    public long? fk_InstituicaoId { get; set; }
    public Instituicao? Instituicao { get; set; }
}
