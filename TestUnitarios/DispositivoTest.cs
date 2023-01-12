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
    public class DispositivoTest
    {
        /// <summary>
        /// Inicializa el dispositivo.
        /// </summary>
        /// <returns>El dispositivo</returns>
        private Dispositivo InicializarDisppositivo()
        {
            Dispositivo test = new Dispositivo();
            test.estado = "Disponible";
            test.modelo = "GTX Prueba Ti";
            test.idCategoria = 1;
            test.localizacion = "C2";
            test.marca = "DELL";
            test.numSerie = "AAHAHAHAHT";

            return test;
        }

        /// <summary>
        /// Inserta un dispositivo, debería insertarlo.
        /// </summary>
        [TestMethod]
        public void TestInsertarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(true, m.InsertarDispositivo(test));
        }

        /// <summary>
        /// Inserta un dispositivo, no debería insertarlo ya que fue insertado.
        /// </summary>
        [TestMethod]
        public void TestInsertarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(false, m.InsertarDispositivo(test));
        }

        /// <summary>
        /// Modifica un dispositivo, debería modificarlo.
        /// </summary>
        [TestMethod]
        public void TestModificarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            test.modelo = "RTX Prueba GDDR6";

            Assert.AreEqual(true, m.ModificarDispositivo(test));
        }

        /// <summary>
        /// Modifica un dispositivo, no debería modificarlo ya que fue modificado.
        /// </summary>
        [TestMethod]
        public void TestModificarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = new Dispositivo();

            test.modelo = "No creo que se ponga esto";

            Assert.AreEqual(false, m.ModificarDispositivo(test));
        }

        /// <summary>
        /// Consulta un dispositivo, debería encontrarlo ya que si existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreNotEqual(null, m.ObtenerDispositivo(test.numSerie));
        }

        /// <summary>
        /// Consulta un dispositivo, no debería encontrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestConsultarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();

            Assert.AreEqual(null, m.ObtenerDispositivo("pepeahtrana"));
        }

        /// <summary>
        /// Borra un dispositivo, debería borrarlo ya que existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(true, m.BorrarDispositivo(test.numSerie));
        }

        /// <summary>
        /// Borra un dispositivo, no debería borrarlo ya que no existe.
        /// </summary>
        [TestMethod]
        public void TestBorrarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(false, m.BorrarDispositivo(""));
        }
    }
}
