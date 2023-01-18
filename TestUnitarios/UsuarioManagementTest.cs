using Negocio.Management;
using Negocio.EntitiesDTO;
using System.Text.Json;
using System.Numerics;

namespace TestUnitarios
{
    /// <summary>
    /// Ejecutar las pruebas de arriba hacia abajo.
    /// </summary>
    [TestClass]
    public class UsuarioManagementTest
    {
        private Usuario InicializarUsuario()
        {
            Usuario test = new Usuario();
            test.correo = "test@test.com";
            test.nombre = "Jhon";
            test.primerApellido = "Doe";
            test.segundoApellido = "";
            test.tipo = "P";
            test.contrasenia = "098f6bcd4621d373cade4e832627b4f6"; // test

            return test;
        }

        /// <summary>
        /// Inserta un usuario.
        /// </summary>
        [TestMethod]
        public void TestInsertarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(true, um.InsertarUsuario(test));
        }

        /// <summary>
        /// Intenta insertar un usuario que ya existe.
        /// </summary>
       [TestMethod]
        public void TestInsertarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(false, um.InsertarUsuario(test));
        }

        /// <summary>
        /// Modifica un usuario.
        /// </summary>
        [TestMethod]
        public void TestModificarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            test.nombre = "Willyrex";

            Assert.AreEqual(true, um.ModificarUsuario(test));
        }

        /// <summary>
        /// Modifica un usuario que no existe.
        /// </summary>
        [TestMethod]
        public void TestModificarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = new Usuario();

            test.nombre = "Pepe";

            Assert.AreEqual(false, um.ModificarUsuario(test));
        }

        /// <summary>
        /// Consulta un usuario que existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreNotEqual(null, um.ObtenerUsuario(test.idUsuario));
        }

        /// <summary>
        /// Consulta un usuaio que no existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();

            Assert.AreEqual(null, um.ObtenerUsuario(int.MaxValue));
        }

        /// <summary>
        /// Borra un usuario.
        /// </summary>
        [TestMethod]
        public void TestBorrarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(true, um.BorrarUsuario(test.correo));
        }

        /// <summary>
        /// Borra un usuario que no existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(false, um.BorrarUsuario(test.correo));
        }
    }
}