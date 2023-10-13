using System.ComponentModel.DataAnnotations;

namespace GestaoEscolar.Models;

public class Departamento
{
    [Key]
    public long? DepartamentoID { get; set; }
    public string Nome { get; set; }
}
