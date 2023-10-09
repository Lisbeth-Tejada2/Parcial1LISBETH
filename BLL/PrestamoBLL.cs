using Microsoft.EntityFrameworkCore;
using Parcial1LISBETH.DAL;
using Parcial1LISBETH.Models;
using System.Linq.Expressions;

namespace Parcial1LISBETH.BLL
{
    public class PrestamoBLL
    {
        private readonly Contexto _context;
        public PrestamoBLL(Contexto context)
        {
            _context = context;    //Recibiendo el contexto
        }

        //Métodos de mi Sistema de Préstamos

        public bool Existe(int PrestamoId)
        {
            return _context.prestamo.Any(i => i.PrestamoId == PrestamoId);
        }

        public Prestamo? Buscar(int PrestamoId)
        {
            return _context.prestamo.Where(i => i.PrestamoId == PrestamoId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public bool Insertar(Prestamo prestamo)
        {
            _context.prestamo.Add(prestamo);
            int cantidad = _context.SaveChanges();
            return cantidad > 0;
        }

        public bool Guardar(Prestamo prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public bool Modificar(Prestamo prestamo)
        {
            _context.prestamo.Entry(prestamo).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(Prestamo prestamo)
        {
            var entity = _context.prestamo.Attach(prestamo);
            _context.prestamo.Remove(entity.Entity);
            int eliminado = _context.SaveChanges();
            return eliminado > 0;
        }
       
        public List<Prestamo> Listar(Expression<Func<Prestamo, bool>> criterio)
        {
            return _context.prestamo
                .Where(criterio)
                .AsNoTracking().ToList();
        }

    }
}
