

namespace DesafioCRUD.DTO.Tasks
{
    public record TaskCreateDto(string Title, DateTime? DueDate, TaskStatus? Status);
}
