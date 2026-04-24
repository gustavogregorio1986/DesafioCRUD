using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.Repository.Repository.Interface;


namespace DesafioCRUD.Service.Service
{
    public class LeadService
    {
        private readonly IGenericRepository<Lead> _leadRepo;

        public LeadService(IGenericRepository<Lead> leadRepo)
        {
            _leadRepo = leadRepo;
        }

        public async Task<IEnumerable<Lead>> ListarLeadsAsync()
        {
            return await _leadRepo.GetAllAsync();
        }

        // Buscar Lead por Id
        public async Task<Lead?> BuscarLeadPorIdAsync(int id)
        {
            return await _leadRepo.GetByIdAsync(id);
        }

        public async Task CriarLeadAsync(Lead lead)
        {
            await _leadRepo.AddAsync(lead);
        }

        // Atualizar Lead existente
        public async Task AtualizarLeadAsync(Lead lead)
        {
            await _leadRepo.UpdateAsync(lead);
        }

        // Remover Lead
        public async Task RemoverLeadAsync(int id)
        {
            await _leadRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Lead>> FiltrarLeadsAsync(string? nome, string? email, DesafioCRUD.Dominio.Dominio.TaskStatus? status)
        {
            return await _leadRepo.FindAsync(l =>
                (string.IsNullOrEmpty(nome) || l.Name.Contains(nome)) &&
                (string.IsNullOrEmpty(email) || l.Email.Contains(email)) &&
                (!status.HasValue || l.Tasks.Any(t => t.Status == status.Value))
            );
        }
    }
}
