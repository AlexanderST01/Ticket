using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ticket.DAL;
using Ticket.Models;

namespace Ticket.BLL
{
    public class SistemasBLL
    {
        private readonly Contexts _context;

        public SistemasBLL(Contexts context)
        {
            _context = context;
        }
        public bool Existe(int SistemaId)
        {
            return _context.Sistemas.Any(s => s.SistemasId == SistemaId);
        }
        public bool Insertar(Sistemas sistemas)
        {
            _context.Sistemas.Add(sistemas);
            return _context.SaveChanges() > 0;
        }
        public bool Modificar(Sistemas sistemas)
        {
            _context.Entry(_context.Sistemas.Find(sistemas.SistemasId)!)
            .State = EntityState.Detached;
            _context.Entry(sistemas).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public bool Guardar(Sistemas sistemas)
        {
            if (!Existe(sistemas.SistemasId))
                return Insertar(sistemas);

            else
                return Modificar(sistemas);
        }
        public bool Eliminar(Sistemas sistemas)
        {
            _context.Sistemas.Entry(_context.Sistemas.Find(sistemas.SistemasId)!).State = EntityState.Detached;
            _context.Sistemas.Entry(sistemas).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public Sistemas? Buscar(int sistemasId)
        {
            return _context.Sistemas
                .Where(s => s.SistemasId == sistemasId)
                .AsNoTracking()
                .SingleOrDefault();
        }
        public List<Sistemas> GetList(Expression<Func<Sistemas, bool>> criterio)
        {
            return _context.Sistemas
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
