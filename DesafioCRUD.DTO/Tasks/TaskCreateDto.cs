

using System.ComponentModel.DataAnnotations;

namespace DesafioCRUD.DTO.Tasks
{
    public record TaskCreateDto(
        [Required(ErrorMessage = "O titulo é obrigfatorio")]
        string Title,
        [Required(ErrorMessage = "A data é obrigfatorio")]
        DateTime? DueDate,
        [Required(ErrorMessage = "O status é obrigfatorio")]
        TaskStatus? Status);
}
