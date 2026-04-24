using DesafioCRUD.Dominio.Dominio;

namespace DesafioCRUD.DTO.Tasks
{
    public record TaskDto(
        int Id,
        int LeadId,
        string Title,
        DateTime? DueDate,
        Dominio.Dominio.TaskStatus Status,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
