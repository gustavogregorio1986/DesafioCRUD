using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCRUD.Service.Service
{
    public class TaskItemService
    {
        private readonly IGenericRepository<TaskItem> _taskRepo;

        public TaskItemService(IGenericRepository<TaskItem> taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IEnumerable<TaskItem>> ListarTasksAsync()
        {
            return await _taskRepo.GetAllAsync();
        }

        // Buscar Task por Id
        public async Task<TaskItem?> BuscarTaskPorIdAsync(int id)
        {
            return await _taskRepo.GetByIdAsync(id);
        }

        // Criar nova Task
        public async Task CriarTaskAsync(TaskItem task)
        {
            await _taskRepo.AddAsync(task);
        }

        public async Task AtualizarTaskAsync(TaskItem task)
        {
            await _taskRepo.UpdateAsync(task);
        }

        // Remover Task
        public async Task RemoverTaskAsync(int id)
        {
            await _taskRepo.DeleteAsync(id);
        }
    }
}
