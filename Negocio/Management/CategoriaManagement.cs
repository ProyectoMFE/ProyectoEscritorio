using Datos.DAO;
using Datos.Infrastructure;
using Negocio.EntitiesDTO;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace Negocio.Management
{
    public class CategoriaManagement
    {
        public Categoria ObtenerCategoria(int id)
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Categorias/" + id);
            string json = HttpConnection.ResponseToJson(res);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(json);
            return categoria;
        }

        public List<Categoria> ObtenerCategorias()
        {
            WebResponse res = HttpConnection.Send(null, "GET", "api/Categorias");
            string json = HttpConnection.ResponseToJson(res);
            List<Categoria> lista = JsonSerializer.Deserialize<List<Categoria>>(json);

            return lista;
        }

        public bool ModificarCategoria(Categoria categoria)
        {
            return false;
        }

        public bool InsertarCategoria(Categoria categoria)
        {
            return false;
        }

        public bool BorrarCategoria(int idCategoria)
        {
            return true;
        }
    }
}
