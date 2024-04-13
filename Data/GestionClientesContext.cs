using API_GestionCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace API_GestionCliente.Data
{
    public class GestionClientesContext: DbContext
    {
        public GestionClientesContext(DbContextOptions<GestionClientesContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
