﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure;

namespace Datos.DAO
{
    public class UsuarioDAO : DAO<USUARIOS>
    {
        private ProyectoMFEEntities contexto;

        public UsuarioDAO ()
        {
            this.contexto = new ProyectoMFEEntities();
        }

        public bool Borrar(object id)
        {
            USUARIOS usuario;

            try
            {
                usuario = Buscar(id);
                contexto.USUARIOS.Remove(usuario);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public USUARIOS Buscar(object id)
        {
            return contexto.USUARIOS.Where(p => p.CORREO.Equals(id)).First();
        }

        public List<USUARIOS> Consultar()
        {
            return contexto.USUARIOS.ToList();
        }

        public bool Insertar(USUARIOS id)
        {
            USUARIOS usuario;

            try
            {
                usuario = Buscar(id);
                contexto.USUARIOS.Add(usuario);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(object id, USUARIOS nuevo)
        {
            USUARIOS usuario;

            try
            {
                usuario = Buscar(id);

                usuario.CONTRASENIA = nuevo.CONTRASENIA;
                usuario.SEGUNDO_APELLIDO = nuevo.SEGUNDO_APELLIDO;
                usuario.PRIMER_APELLIDO = nuevo.PRIMER_APELLIDO;
                usuario.NOMBRE = nuevo.NOMBRE;
                usuario.CORREO = nuevo.CORREO;
                usuario.ID_USUARIO = nuevo.ID_USUARIO;
                usuario.CORREO = nuevo.CORREO;
                usuario.TIPO = nuevo.TIPO;

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
