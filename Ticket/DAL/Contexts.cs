using Microsoft.EntityFrameworkCore;
using Ticket.Models;

namespace Ticket.DAL
{
    public class Contexts : DbContext
    {
        public DbSet<Tickets> Tickets { set; get; }
        public DbSet<Clientes> Clientes { set; get; }
        public DbSet<Prioridades> Prioridades { set; get; }
        public DbSet<Sistemas> Sistemas { set; get; }
        public Contexts(DbContextOptions<Contexts> options) : base(options)
        { }
    }
}
