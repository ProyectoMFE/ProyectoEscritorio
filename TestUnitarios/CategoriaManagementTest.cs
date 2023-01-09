using Negocio.EntitiesDTO;
using Negocio.Management;

namespace TestUnitarios
{
    [TestClass]
    public class CategoriaManagementTest
    {
        private Categoria InicializarCategoria()
        {
            Categoria test = new Categoria();
            test.idCategoria = 1488;
            test.nombre = "Prueba";

            return test;
        }

        [TestMethod]
        public void TestInsertarTrue()
        {
            CategoriaManagement m = new CategoriaManagement();
            Categoria test = InicializarCategoria();

            Assert.AreEqual(true, m.InsertarCategoria(test));
        }

        [TestMethod]
        public void TestInsertarFalse()
        {
            CategoriaManagement m = new CategoriaManagement();
            Categoria test = InicializarCategoria();

            Assert.AreEqual(false, m.InsertarCategoria(test));
        }

        [TestMethod]
        public void TestConsultarTrue()
        {
            CategoriaManagement m = new CategoriaManagement();
            Categoria test = InicializarCategoria();
            
            Assert.AreNotEqual(null, m.ObtenerCategoria(test.idCategoria));
        }

        [TestMethod]
        public void TestConsultarFalse()
        {
            CategoriaManagement m = new CategoriaManagement();

            Assert.AreEqual(null, m.ObtenerCategoria(int.MaxValue));
        }

        [TestMethod]
        public void TestBorrarTrue()
        {
            CategoriaManagement m = new CategoriaManagement();
            Categoria test = InicializarCategoria();

            Assert.AreEqual(true, m.BorrarCategoria(test.idCategoria));
        }

        [TestMethod]
        public void TestBorrarFalse()
        {
            CategoriaManagement m = new CategoriaManagement();
            Categoria test = InicializarCategoria();

            Assert.AreEqual(false, m.BorrarCategoria(test.idCategoria));
        }
    }
}
