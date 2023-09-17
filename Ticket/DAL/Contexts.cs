using Microsoft.EntityFrameworkCore;
using Ticket.Models;

namespace Ticket.DAL
{
    public class Contexts : DbContext
    {
        DbSet<Tickets> Tickets { set; get; }
        DbSet<Clientes> Clientes { set; get; }
        DbSet<Prioridades> Prioridades { set; get; }
        DbSet<Sistemas> Sistemas { set; get; }
        public Contexts(DbContextOptions<Contexts> options): base(options)
        { }
    }
}
