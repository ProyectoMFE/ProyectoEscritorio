using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    interface DAO<T>
    {
        bool Insertar(T objeto);
        T Buscar(object id);
        bool Borrar(object id);
        bool Modificar(object id, T nuevo);
        List<T> Consultar();
    }
}
