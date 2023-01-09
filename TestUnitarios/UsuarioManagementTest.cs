using Negocio.Management;
using Negocio.EntitiesDTO;
using System.Text.Json;

namespace TestUnitarios
{
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

        [TestMethod]
        public void TestInsertarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(true, um.InsertarUsuario(test));
        }

       [TestMethod]
        public void TestInsertarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(false, um.InsertarUsuario(test));
        }

        [TestMethod]
        public void TestBorrarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(true, um.BorrarUsuario(test.correo));
        }

        [TestMethod]
        public void TestBorrarFalse()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            Assert.AreEqual(false, um.BorrarUsuario(test.correo));
        }

        [TestMethod]
        public void TestModificarTrue()
        {
            UsuarioManagement um = new UsuarioManagement();
            Usuario test = InicializarUsuario();

            test.nombre = "Willyrex";

            Assert.AreEqual(true, um.ModificarUsuario(test));
        }
    }
}