using DesafioCRUD.Dominio.Dominio;
using System.ComponentModel.DataAnnotations;

namespace DesafioCRUD.DTO.Leads
{
    public record LeadCreateDto(
        [Required(ErrorMessage = "O nome é obrigfatorio")]
        string Name,
        [Required(ErrorMessage = "O email é obrigfatorio")]
        string Email,
        [Required(ErrorMessage = "O status é obrigfatorio")]
        LeadStatus? Status);
}
