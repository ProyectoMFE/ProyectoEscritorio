using Negocio.Management;
using Negocio.EntitiesDTO;

namespace TestUnitarios
{
    [TestClass]
    public class UsuarioManagementTest
    {
        [TestMethod]
        public void TestLogin()
        {
            bool insertado = new UsuarioManagement().InsertarUsuario(new Usuario());
        }
    }
}