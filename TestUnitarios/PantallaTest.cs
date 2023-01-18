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
    public class PantallaTest
    {
        /// <summary>
        /// Inicializa el Pantalla.
        /// </summary>
        /// <returns>El Pantalla</returns>
        private Pantalla InicializarDisppositivo()
        {
            Pantalla test = new Pantalla();
            test.pulgadas = 27;
            test.numSerie = "PRUEBA";

            return test;
        }

        /// <summary>
        /// Inserta un Pantalla, debería insertarlo.
        /// </summary>
        [TestMethod]
        public void TestInsertarTrue()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            Assert.AreEqual(true, m.InsertarPantalla(test));
        }

        /// <summary>
        /// Inserta un Pantalla, no debería insertarlo ya que fue insertado.
        /// </summary>
        [TestMethod]
        public void TestInsertarFalse()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            Assert.AreEqual(false, m.InsertarPantalla(test));
        }

        /// <summary>
        /// Modifica un Pantalla, debería modificarlo.
        /// </summary>
        [TestMethod]
        public void TestModificarTrue()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            test.pulgadas = 28;

            Assert.AreEqual(true, m.ModificarPantalla(test));
        }

        /// <summary>
        /// Modifica un Pantalla, no debería modificarlo ya que fue modificado.
        /// </summary>
        [TestMethod]
        public void TestModificarFalse()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = new Pantalla();

            test.pulgadas = 777;

            Assert.AreEqual(false, m.ModificarPantalla(test));
        }

        /// <summary>
        /// Consulta un Pantalla, debería encontrarlo ya que si existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarTrue()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            Assert.AreNotEqual(null, m.ObtenerPantalla(test.numSerie));
        }

        /// <summary>
        /// Consulta un Pantalla, no debería encontrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarFalse()
        {
            PantallaManagement m = new PantallaManagement();

            Assert.AreEqual(null, m.ObtenerPantalla("pepea"));
        }

        /// <summary>
        /// Borra un Pantalla, debería borrarlo ya que existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarTrue()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            Assert.AreEqual(true, m.BorrarPantalla(test.numSerie));
        }

        /// <summary>
        /// Borra un Pantalla, no debería borrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarFalse()
        {
            PantallaManagement m = new PantallaManagement();
            Pantalla test = InicializarDisppositivo();

            Assert.AreEqual(false, m.BorrarPantalla(""));
        }
    }
}