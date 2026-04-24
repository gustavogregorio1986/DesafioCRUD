using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.Dominio.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCRUD.Data.Data
{
    public class DesafioCRUDContexto : DbContext
    {
        public DesafioCRUDContexto(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeadMapping());
            modelBuilder.ApplyConfiguration(new TaskItemMapping());
        }
    }
}
