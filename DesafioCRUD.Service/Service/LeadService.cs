using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
