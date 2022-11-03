using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    public interface DAO<T>
    {
        bool insertar(T id);
        T buscar(object id);
        bool borrar(object id);
        bool modificar(object id, T nuevo);
        List<T> consultar();
    }
}
