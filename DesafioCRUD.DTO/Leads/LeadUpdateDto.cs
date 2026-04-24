using DesafioCRUD.Dominio.Dominio;


namespace DesafioCRUD.DTO.Leads
{
    public record LeadUpdateDto(string Name, string Email, LeadStatus Status);
}
