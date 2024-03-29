﻿using Datos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DAO
{
    /// <summary>
    /// Clase que realiza operaciondes de lectura, escritura, borrado y modificiacion de 
    /// los ordenadores que hay en la base de datos.
    /// </summary>
    public class OrdenadorDAO : DAO<ORDENADORES>
    {
        private ProyectoMFEEntities contexto;

        public OrdenadorDAO()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            ORDENADORES dispositivo;

            try
            {
                dispositivo = Buscar(id);
                contexto.ORDENADORES.Remove(dispositivo);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ORDENADORES Buscar(object id)
        {
            try
            {
                return contexto.ORDENADORES.Where(p => p.NUM_SERIE == id).First();
            }
            catch (Exception)
            {
                return new ORDENADORES();
            }
        }

        public List<ORDENADORES> Consultar()
        {
            return contexto.ORDENADORES.ToList();
        }

        public bool Insertar(ORDENADORES objeto)
        {
            try
            {
                contexto.ORDENADORES.Add(objeto);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, ORDENADORES nuevo)
        {
            ORDENADORES dispositivo;

            try
            {
                dispositivo = Buscar(id);

                dispositivo.NUM_SERIE = nuevo.NUM_SERIE;
                dispositivo.RAM = nuevo.RAM;
                dispositivo.PROCESADOR = nuevo.PROCESADOR;
                dispositivo.DISCO_PRINCIPAL = nuevo.DISCO_PRINCIPAL;
                dispositivo.DISCO_SECUNDARIO = nuevo.DISCO_SECUNDARIO;

                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
