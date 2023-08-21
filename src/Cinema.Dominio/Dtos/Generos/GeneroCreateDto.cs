using Cinema.Dominio.Common;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Dominio.Dtos.Generos
{
    public class GeneroCreateDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
