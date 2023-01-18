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
    public class HWRedTest
    {
        /// <summary>
        /// Inicializa el HWRed.
        /// </summary>
        /// <returns>El HWRed</returns>
        private HWRed InicializarDisppositivo()
        {
            HWRed test = new HWRed();
            test.velocidad = 1000;
            test.numPuertos = 64;
            test.numSerie = "PRUEBA";

            return test;
        }

        /// <summary>
        /// Inserta un HWRed, debería insertarlo.
        /// </summary>
        [TestMethod]
        public void TestInsertarTrue()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            Assert.AreEqual(true, m.InsertarHWRed(test));
        }

        /// <summary>
        /// Inserta un HWRed, no debería insertarlo ya que fue insertado.
        /// </summary>
        [TestMethod]
        public void TestInsertarFalse()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            Assert.AreEqual(false, m.InsertarHWRed(test));
        }

        /// <summary>
        /// Modifica un HWRed, debería modificarlo.
        /// </summary>
        [TestMethod]
        public void TestModificarTrue()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            test.numPuertos = 128;

            Assert.AreEqual(true, m.ModificarHWRed(test));
        }

        /// <summary>
        /// Modifica un HWRed, no debería modificarlo ya que fue modificado.
        /// </summary>
        [TestMethod]
        public void TestModificarFalse()
        {
            HWManagement m = new HWManagement();
            HWRed test = new HWRed();

            test.numPuertos = 777;

            Assert.AreEqual(false, m.ModificarHWRed(test));
        }

        /// <summary>
        /// Consulta un HWRed, debería encontrarlo ya que si existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarTrue()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            Assert.AreNotEqual(null, m.ObtenerHWRed(test.numSerie));
        }

        /// <summary>
        /// Consulta un HWRed, no debería encontrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarFalse()
        {
            HWManagement m = new HWManagement();

            Assert.AreEqual(null, m.ObtenerHWRed("pepeahtrana"));
        }

        /// <summary>
        /// Borra un HWRed, debería borrarlo ya que existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarTrue()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            Assert.AreEqual(true, m.BorrarHWRed(test.numSerie));
        }

        /// <summary>
        /// Borra un HWRed, no debería borrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarFalse()
        {
            HWManagement m = new HWManagement();
            HWRed test = InicializarDisppositivo();

            Assert.AreEqual(false, m.BorrarHWRed(""));
        }
    }
}
