using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Acceder
    {
        public static void Listar()
        {
            using (var contexto = new ProyectoMFEEntities())
            {
                List<DISPOSITIVOS> dispositivos = contexto.DISPOSITIVOS.ToList();
            }
        }

    }
}
