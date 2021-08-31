using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data
{
    public class FilmeContext : DbContext // definindo essa classe como um contexto para utilizarmos o banco de dados
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt): base (opt){ // iremos passa como parametro para dbContext

        }

        public DbSet<filme> Filmes {get; set;} //dbset conjunto de dados do banco de dados onde posso manipular
    }
}