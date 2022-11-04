﻿using System;
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
            return contexto.DISPOSITIVOS.Where(p => p.NUM_SERIE.Equals(id)).First();
        }

        public List<DISPOSITIVOS> Consultar()
        {
            return contexto.DISPOSITIVOS.ToList();
        }

        public bool Insertar(DISPOSITIVOS id)
        {
            DISPOSITIVOS dispositivo;

            try
            {
                dispositivo = Buscar(id);
                contexto.DISPOSITIVOS.Add(dispositivo);
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
    }
}
