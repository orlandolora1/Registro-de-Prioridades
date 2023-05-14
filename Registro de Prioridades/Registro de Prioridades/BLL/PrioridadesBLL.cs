using Microsoft.EntityFrameworkCore;
using Registro_de_Prioridades.Models;
using System.Linq.Expressions;
class PrioridadesBLL
{
    private Contexto _contexto;
    public PrioridadesBLL(Contexto _contexto)
    {
        this._contexto = _contexto;
    }

    public bool Existe(int prioridadId)
    {
        return _contexto.prioridades.Any(p => p.PrioridadId == prioridadId);
    }
    public bool ExisteDescricion(string desc)
    {

        return _contexto.prioridades.Any(p => p.Descripcion == desc);

    }

    public bool Insertar(Prioridades prioridad)
    {
        _contexto.prioridades.Add(prioridad);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Prioridades prioridad)
    {
        _contexto.Entry(prioridad).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Prioridades prioridad)
    {
        if (!Existe(prioridad.PrioridadId))
        {
            if (!ExisteDescricion(prioridad.Descripcion))
            {
                return this.Insertar(prioridad);
            }
            else
            {
                return false;
            }
        }

        else
            return this.Modificar(prioridad);
    }

    public bool Eliminar(Prioridades prioridad)
    {
        _contexto.Entry(prioridad).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Prioridades? Buscar(int prioridadId)
    {
        return _contexto.prioridades.Where(b => b.PrioridadId == prioridadId).AsNoTracking().SingleOrDefault();
    }
    public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
    {
        return _contexto.prioridades.AsNoTracking().Where(criterio).ToList();
    }

}