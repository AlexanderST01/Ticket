using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ticket.DAL;
using Ticket.Models;

namespace Ticket.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexts _context;

        public PrioridadesBLL(Contexts context)
        {
            _context = context;
        }
        public bool Existe(int prioridadId)
        {
            return _context.Prioridades.Any(p => p.PrioridadId == prioridadId);
        }
        public bool Insertar(Prioridades prioridad)
        {
            _context.Prioridades.Add(prioridad);
            return _context.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades prioridad)
        {
            _context.Entry(_context.Prioridades.Find(prioridad.PrioridadId)!)
            .State = EntityState.Modified;
            _context.Entry(prioridad).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public bool Guardar(Prioridades prioridad)
        {
            if (!Existe(prioridad.PrioridadId))
                return Insertar(prioridad);

            else
                return Modificar(prioridad);
        }
        public bool Eliminar(Prioridades prioridad)
        {
            _context.Prioridades.Entry(_context.Prioridades.Find(prioridad.PrioridadId)!).State = EntityState.Detached;
            _context.Prioridades.Entry(prioridad).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public Prioridades? Buscar(int prioridadId)
        {
            return _context.Prioridades
                .Where(p => p.PrioridadId == prioridadId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
        {
            return _context.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
