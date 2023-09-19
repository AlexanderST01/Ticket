using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Ticket.DAL;
using Ticket.Models;
using System.Linq.Expressions;

namespace Ticket.BLL
{
    public class ClientesBLL
    {
        private readonly Contexts _context;

        public ClientesBLL(Contexts context)
        {
            _context = context;
        }
        public bool Existe(int clienteId)
        {
            return _context.Clientes.Any(c => c.ClienteId == clienteId);
        }
        public bool Insertar(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            return _context.SaveChanges() > 0;
        }
        public bool Modificar(Clientes cliente)
        {
            _context.Entry(_context.Clientes.Find(cliente.ClienteId)!)
            .State = EntityState.Detached;
            _context.Entry(cliente).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);

            else
                return Modificar(cliente);
        }
        public bool Eliminar(Clientes clientes)
        {
            _context.Clientes.Entry(_context.Clientes.Find(clientes.ClienteId)!).State = EntityState.Detached;
            _context.Clientes.Entry(clientes).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public Clientes? Buscar( int clienteId)
        {
            return _context.Clientes
                .Where(c => c.ClienteId == clienteId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            return _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
