using Ticket.DAL;
using Ticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ticket.BLL
{
    public class TicketsBLL
    {
        private readonly Contexts _context;

        public TicketsBLL(Contexts context)
        {
            _context = context;
        }

        public bool Existe(int ticketId)
        {
            return _context.Tickets.Any(t =>  t.TicketId == ticketId);
        }
        public bool Insertar(Tickets tickets)
        {
            _context.Tickets.Add(tickets);
            return _context.SaveChanges() > 0;
        }
        public bool Modificar(Tickets tickets)
        {
            _context.Entry(_context.Tickets.Find(tickets.TicketId)!).State = EntityState.Modified;
            _context.Entry(tickets).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public bool Guardar(Tickets tickets)
        {
            if (!Existe(tickets.TicketId))
                return this.Insertar(tickets);

            else
                return this.Modificar(tickets);
        }
        public bool Eliminar(Tickets tickets)
        {
            _context.Entry(_context.Tickets.Find(tickets.TicketId)!).State = EntityState.Detached;
            _context.Entry(tickets).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public Tickets? Buscar(int ticketId)
        {
            return _context.Tickets
                .Where(t => t.TicketId == ticketId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Tickets>GetTickets(Expression<Func<Tickets,bool>> criterio)
        {
            return _context.Tickets
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
