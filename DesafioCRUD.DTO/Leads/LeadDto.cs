using DesafioCRUD.Dominio.Dominio;

namespace DesafioCRUD.DTO.Leads
{
    public record LeadDto(
        int Id,
        string Name,
        string Email,
        LeadStatus Status,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        int TasksCount
    );
}
