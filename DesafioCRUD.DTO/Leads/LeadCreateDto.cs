using DesafioCRUD.Dominio.Dominio;

namespace DesafioCRUD.DTO.Leads
{
    public record LeadCreateDto(string Name, string Email, LeadStatus? Status);
}
