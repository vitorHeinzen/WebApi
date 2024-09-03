using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        //configuração do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=WebApiBD;" + 
                "User Id=postgres;" +
                "Password=Vitor@0907;");
        }
    }
}
