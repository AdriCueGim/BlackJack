using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class CartaTests
    {
        private Carta[] _cartas;

        [SetUp]
        protected void SetUp()
        {
            _cartas = new Carta[]
            {
                new Carta(Carta.Valor.As, Carta.Palo.Corazones),
                new Carta(Carta.Valor.Jota, Carta.Palo.Diamantes),
                new Carta(Carta.Valor.Rey, Carta.Palo.Treboles),
                new Carta(Carta.Valor.Reina, Carta.Palo.Picas),
                new Carta(Carta.Valor.Nueve, Carta.Palo.Corazones),
                new Carta(Carta.Valor.Diez, Carta.Palo.Diamantes),
                new Carta(Carta.Valor.Ocho, Carta.Palo.Treboles),
                new Carta(Carta.Valor.Dos, Carta.Palo.Picas)
            };
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("A \u0003", _cartas[0].ToString());
            Assert.AreEqual("J \u0004", _cartas[1].ToString());
            Assert.AreEqual("K \u0005", _cartas[2].ToString());
            Assert.AreEqual("Q \u0006", _cartas[3].ToString());
            Assert.AreEqual("9 \u0003", _cartas[4].ToString());
            Assert.AreEqual("10 \u0004", _cartas[5].ToString());
            Assert.AreEqual("8 \u0005", _cartas[6].ToString());
            Assert.AreEqual("2 \u0006", _cartas[7].ToString());
        }
    }
}