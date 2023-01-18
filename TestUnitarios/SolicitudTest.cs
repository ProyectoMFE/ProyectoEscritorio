using Negocio.Management;
using Negocio.EntitiesDTO;
using System.Text.Json;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace TestUnitarios
{
    /// <summary>
    /// Ejecutar las pruebas de arriba hacia abajo.
    /// </summary>
    [TestClass]
    public class SolicitudTest
    {
        /// <summary>
        /// Crear una soliciud.
        /// </summary>
        [TestMethod]
        public void CrearSolicitudTest()
        {
            Usuario usuario = new Usuario();
            Dispositivo dispositivo = new Dispositivo();
            UsuarioManagement u = new UsuarioManagement();
            DispositivoManagement d = new DispositivoManagement();
            SolicitudManagement s = new SolicitudManagement();

            usuario.correo = "test@test.com";
            usuario.nombre = "Jhon";
            usuario.primerApellido = "Doe";
            usuario.segundoApellido = "";
            usuario.tipo = "P";
            usuario.contrasenia = "098f6bcd4621d373cade4e832627b4f6"; // test

            dispositivo.estado = "Disponible";
            dispositivo.modelo = "GTX Prueba Ti";
            dispositivo.idCategoria = 1;
            dispositivo.localizacion = "C2";
            dispositivo.marca = "DELL";
            dispositivo.numSerie = "prueba";

            u.InsertarUsuario(usuario);
            d.InsertarDispositivo(dispositivo);
            s.insertarSolicitud(usuario.correo, dispositivo.numSerie);

            Assert.AreNotEqual(0, s.obtenerSolicitudes(usuario.correo, dispositivo.numSerie).Count);
        }

        /// <summary>
        /// Rechazar una solicitud.
        /// </summary>
        [TestMethod]
        public void RechazarSolicitudTest()
        {
            SolicitudManagement s = new SolicitudManagement();
            DispositivoManagement d = new DispositivoManagement();

            s.rechazarSolicitud("test@test.com", "prueba");

            Assert.AreEqual(0, s.obtenerSolicitudes("test@test.com", "prueba").Count);
            Assert.AreEqual(d.ObtenerDispositivo("prueba").estado, "Disponible");

            s.insertarSolicitud("test@test.com", "prueba");
        }

        /// <summary>
        /// Aceptar una solicitud.
        /// </summary>
        [TestMethod]
        public void AceptarSolicitudTest()
        {
            SolicitudManagement s = new SolicitudManagement();
            DispositivoManagement d = new DispositivoManagement();

            s.aceptarSolicitud("test@test.com", "prueba");

            Assert.AreEqual("Aceptado", s.obtenerSolicitudes("test@test.com", "prueba").ElementAt(0).estado);
            Assert.AreEqual(d.ObtenerDispositivo("prueba").estado, "Ocupado");
        }

        /// <summary>
        /// Finalizar una solicitud.
        /// </summary>
        [TestMethod]
        public void FinalizarSolicitudTest()
        {
            SolicitudManagement s = new SolicitudManagement();
            DispositivoManagement d = new DispositivoManagement();

            s.finalizarSolicitud("test@test.com", "prueba");

            Assert.AreEqual(0, s.obtenerSolicitudes("test@test.com", "prueba").Count);
            Assert.AreEqual(d.ObtenerDispositivo("prueba").estado, "Disponible");
        }
    }
}
