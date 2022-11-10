using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    public class DispositivoDAO : DAO<DISPOSITIVOS>
    {
        private ProyectoMFEEntities contexto;

        public DispositivoDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            DISPOSITIVOS dispositivo;

            try
            {
                dispositivo = Buscar(id);
                contexto.DISPOSITIVOS.Remove(dispositivo);
                contexto.SaveChanges();

                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public DISPOSITIVOS Buscar(object id)
        {
            try
            {
                return contexto.DISPOSITIVOS.Where(p => p.NUM_SERIE == id).First();
            }
            catch (Exception)
            {
                return new DISPOSITIVOS();
            }
        }

        public List<DISPOSITIVOS> Consultar()
        {
            return contexto.DISPOSITIVOS.ToList();
        }

        public bool Insertar(DISPOSITIVOS objeto)
        {
            try
            {
                contexto.DISPOSITIVOS.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, DISPOSITIVOS nuevo)
        {
            DISPOSITIVOS dispositivo;

            try
            {
                dispositivo = Buscar(id);

                dispositivo.NUM_SERIE = nuevo.NUM_SERIE;
                dispositivo.ID_CATEGORIA = nuevo.ID_CATEGORIA;
                dispositivo.ESTADO = nuevo.ESTADO;
                dispositivo.MARCA = nuevo.MARCA;
                dispositivo.MODELO = nuevo.MODELO;
                dispositivo.LOCALIZACION = nuevo.LOCALIZACION;

                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
 
        public List<DISPOSITIVOS> ObtenerDispositivosPorCategoria(List<string> categorias)
        {
            List<DISPOSITIVOS> listaDispositivos = new List<DISPOSITIVOS>();
            List<DISPOSITIVOS> listaDispositivosPorCategoria = null;           

            try
            {
                foreach (string categoria in categorias)
                {
                    listaDispositivosPorCategoria =  contexto.DISPOSITIVOS.ToList();

                    foreach (DISPOSITIVOS dispositivo in listaDispositivosPorCategoria)
                    {
                        if (dispositivo.CATEGORIAS.NOMBRE.Equals(categoria))
                        {
                            listaDispositivos.Add(dispositivo);
                        }
                  
                    }
                }
            }
            catch (Exception)
            {
            }
            return listaDispositivos;

        }

        public List<DISPOSITIVOS> ObtenerDispositivosPorMarca(List<string>marcas)
        {
            List<DISPOSITIVOS> listaDispositivos = new List<DISPOSITIVOS>();
            List<DISPOSITIVOS> listaDispositivosPorMarca=null;

            try
            {
                foreach (string marca in marcas)
                {
                    listaDispositivosPorMarca = contexto.DISPOSITIVOS.Where(p => p.MARCA == marca).ToList();
                    foreach (DISPOSITIVOS dispositivo in listaDispositivosPorMarca)
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            catch (Exception)
            {            
            }
            return listaDispositivos;
        }
        public List<DISPOSITIVOS> ObtenerDispositivosPorModelo(List<string> modelos)
        {
            List<DISPOSITIVOS> listaDispositivos = new List<DISPOSITIVOS>();
            List<DISPOSITIVOS> listaDispositivosPorModelo = null;

            try
            {
                foreach (string modelo in modelos)
                {
                    listaDispositivosPorModelo = contexto.DISPOSITIVOS.Where(p => p.MODELO == modelo).ToList();
                    foreach (DISPOSITIVOS dispositivo in listaDispositivosPorModelo)
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            catch (Exception)
            {
            }
            return listaDispositivos;
        }
        public List<DISPOSITIVOS> ObtenerDispositivosPorLocalizaciones(List<string> localizaciones)
        {
            List<DISPOSITIVOS> listaDispositivos = new List<DISPOSITIVOS>();
            List<DISPOSITIVOS> listaDispositivosPorLocalizacion = null;

            try
            {
                foreach (string localizacion in localizaciones)
                {
                    listaDispositivosPorLocalizacion = contexto.DISPOSITIVOS.Where(p => p.LOCALIZACION == localizacion).ToList();
                    foreach (DISPOSITIVOS dispositivo in listaDispositivosPorLocalizacion)
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            catch (Exception)
            {
            }
            return listaDispositivos;
        }
        public List<DISPOSITIVOS> ObtenerDispositivosPorEstados(List<string> estados)
        {
            List<DISPOSITIVOS> listaDispositivos = new List<DISPOSITIVOS>();
            List<DISPOSITIVOS> listaDispositivosPorEstado = null;

            try
            {
                foreach (string estado in estados)
                {
                    listaDispositivosPorEstado = contexto.DISPOSITIVOS.Where(p => p.ESTADO == estado).ToList();
                    foreach (DISPOSITIVOS dispositivo in listaDispositivosPorEstado)
                    {
                        listaDispositivos.Add(dispositivo);
                    }
                }
            }
            catch (Exception)
            {
            }
            return listaDispositivos;
        }
    }
}
