using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class MazoTests
    {
        private Mazo _mazo;

        [SetUp]
        protected void SetUp()
        {
            _mazo = new Mazo();
        }

        [Test()]
        [MaxTime(2000)]
        public void AñadeBarajaTest()
        {
            _mazo.AñadeBaraja();
            _mazo.AñadeBaraja();
            _mazo.AñadeBaraja();
            _mazo.AñadeBaraja();
            Assert.AreEqual(208, _mazo.NumeroCartas);
        }

        [Test()]
        public void RecorreBarajaTest()
        {
            _mazo.AñadeBaraja();
            _mazo.AñadeBaraja();
            int i = 0;
            foreach (var c in _mazo)
            {
                c.ToString();
                i++;
            }
            Assert.AreEqual(104, i);
        }

        [Test()]
        public void AñadeCartaTest()
        {
            _mazo.AñadeCarta(new Carta(Carta.Valor.Reina, Carta.Palo.Picas));
            _mazo.AñadeCarta(new Carta(Carta.Valor.Nueve, Carta.Palo.Corazones));
            Assert.AreEqual(2, _mazo.NumeroCartas);
        }

        [Test()]
        public void ExtraePrimeraTest()
        {
            _mazo.AñadeBaraja();
            Assert.AreEqual(_mazo.ExtraePrimera().ToString(), "A \u0003");
            Assert.AreEqual(51, _mazo.NumeroCartas);
        }

        [Test()]
        [MaxTime(2000)]
        public void MeclaTest()
        {
            _mazo.Mecla();
            _mazo.AñadeBaraja();
            _mazo.Mecla();
            _mazo.AñadeBaraja();
            _mazo.Mecla();
            Assert.AreEqual(104, _mazo.NumeroCartas);
        }
    }
}