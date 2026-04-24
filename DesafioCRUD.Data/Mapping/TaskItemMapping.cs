using DesafioCRUD.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioCRUD.Dominio.Mapping
{
    public class TaskItemMapping : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            // Nome da tabela
            builder.ToTable("tb_Tasks");

            // Chave primária
            builder.HasKey(t => t.Id);

            // Propriedades
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(90);

            builder.Property(t => t.DueDate)
                   .IsRequired(false);

            builder.Property(t => t.Status)
                   .HasConversion<int>() // salva enum como int
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(t => t.UpdatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Relacionamento N:1 com Lead
            builder.HasOne(t => t.Lead)
                   .WithMany(l => l.Tasks)
                   .HasForeignKey(t => t.LeadId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
