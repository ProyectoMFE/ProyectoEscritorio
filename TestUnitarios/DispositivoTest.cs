using Negocio.Management;
using Negocio.EntitiesDTO;
using System.Text.Json;
using System.Numerics;

namespace TestUnitarios
{
    [TestClass]
    public class DispositivoTest
    {
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

        [TestMethod]
        public void TestInsertarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(true, m.InsertarDispositivo(test));
        }

        [TestMethod]
        public void TestInsertarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(false, m.InsertarDispositivo(test));
        }

        [TestMethod]
        public void TestModificarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            test.modelo = "RTX Prueba GDDR6";

            Assert.AreEqual(true, m.ModificarDispositivo(test));
        }

        [TestMethod]
        public void TestModificarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = new Dispositivo();

            test.modelo = "No creo que se ponga esto";

            Assert.AreEqual(false, m.ModificarDispositivo(test));
        }

        [TestMethod]
        public void TestConsultarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreNotEqual(null, m.ObtenerDispositivo(test.numSerie));
        }

        [TestMethod]
        public void TestConsultarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();

            Assert.AreEqual(null, m.ObtenerDispositivo("pepeahtrana"));
        }

        [TestMethod]
        public void TestBorrarTrue()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(true, m.BorrarDispositivo(test.numSerie));
        }

        [TestMethod]
        public void TestBorrarFalse()
        {
            DispositivoManagement m = new DispositivoManagement();
            Dispositivo test = InicializarDisppositivo();

            Assert.AreEqual(false, m.BorrarDispositivo(""));
        }
    }
}
