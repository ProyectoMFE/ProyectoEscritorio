using Negocio.Management;
using Negocio.EntitiesDTO;
using System.Text.Json;
using System.Numerics;

namespace TestUnitarios
{
    /// <summary>
    /// Los test se ejecutan de arriba hacia abajo.
    /// </summary>
    [TestClass]
    public class OrdenadorTest
    {
        /// <summary>
        /// Inicializa el Ordenador.
        /// </summary>
        /// <returns>El Ordenador</returns>
        private Ordenador InicializarDisppositivo()
        {
            Ordenador test = new Ordenador();
            test.discoPrincipal = "1GB";
            test.discoSecundario = "1GB";
            test.procesador = "I5 6500";
            test.numSerie = "PRUEBA";
            test.ram = "8GB DDR4";

            return test;
        }

        /// <summary>
        /// Inserta un Ordenador, debería insertarlo.
        /// </summary>
        [TestMethod]
        public void TestInsertarTrue()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            Assert.AreEqual(true, m.InsertarOrdenador(test));
        }

        /// <summary>
        /// Inserta un Ordenador, no debería insertarlo ya que fue insertado.
        /// </summary>
        [TestMethod]
        public void TestInsertarFalse()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            Assert.AreEqual(false, m.InsertarOrdenador(test));
        }

        /// <summary>
        /// Modifica un Ordenador, debería modificarlo.
        /// </summary>
        [TestMethod]
        public void TestModificarTrue()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            test.ram = "8GB DDR5";

            Assert.AreEqual(true, m.ModificarOrdenador(test));
        }

        /// <summary>
        /// Modifica un Ordenador, no debería modificarlo ya que fue modificado.
        /// </summary>
        [TestMethod]
        public void TestModificarFalse()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = new Ordenador();

            test.procesador = "I7 6700K";

            Assert.AreEqual(false, m.ModificarOrdenador(test));
        }

        /// <summary>
        /// Consulta un Ordenador, debería encontrarlo ya que si existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarTrue()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            Assert.AreNotEqual(null, m.ObtenerOrdenador(test.numSerie));
        }

        /// <summary>
        /// Consulta un Ordenador, no debería encontrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarFalse()
        {
            OrdenadorManagement m = new OrdenadorManagement();

            Assert.AreEqual(null, m.ObtenerOrdenador("pepeahtrana"));
        }

        /// <summary>
        /// Borra un Ordenador, debería borrarlo ya que existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarTrue()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            Assert.AreEqual(true, m.BorrarOrdenador(test.numSerie));
        }

        /// <summary>
        /// Borra un Ordenador, no debería borrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarFalse()
        {
            OrdenadorManagement m = new OrdenadorManagement();
            Ordenador test = InicializarDisppositivo();

            Assert.AreEqual(false, m.BorrarOrdenador(""));
        }
    }
}
