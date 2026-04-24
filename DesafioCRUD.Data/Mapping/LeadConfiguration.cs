using DesafioCRUD.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioCRUD.Dominio.Mapping
{
    public class LeadMapping : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            // Nome da tabela
            builder.ToTable("tb_Leads");

            // Chave primária
            builder.HasKey(l => l.Id);

            // Propriedades
            builder.Property(l => l.Name)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(l => l.Email)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(l => l.Status)
                   .HasConversion<int>() // salva enum como int
                   .IsRequired();

            builder.Property(l => l.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(l => l.UpdatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Relacionamento 1:N com TaskItem
            builder.HasMany(l => l.Tasks)
                   .WithOne(t => t.Lead)
                   .HasForeignKey(t => t.LeadId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
