using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class ApostadorTests
    {
        private Apostador _a0, _a1, _a2;

        [SetUp]
        public void SetUp()
        {
            _a0 = new Apostador("Susana", 1000);
            _a0.Silla = 0;
            _a1 = new Apostador("Maria", 1000);
            _a1.Silla = 1;
            _a1.IniciaMano(100);
            _a1.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _a2 = new Apostador("Juan", 1000);
            _a2.Silla = 2;
            _a2.IniciaMano(200);
            _a2.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _a2.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles));
        }

        [Test()]
        public void IniciaManoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a0.IniciaMano(2000));
            Assert.Throws<Jugador.Excepcion>(() => _a1.IniciaMano(1000));
            _a0.IniciaMano(500);
        }

        [Test()]
        public void PlantarseTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a0.Plantarse());
            _a1.Plantarse();
            Assert.Throws<Jugador.Excepcion>(() => _a2.Plantarse());
        }

        [Test()]
        public void DoblarseTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a0.Doblarse());
            Assert.Throws<Jugador.Excepcion>(() => _a1.Doblarse());
            Assert.Throws<Jugador.Excepcion>(() => _a2.Doblarse());

            _a1.RecibeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));
            Assert.AreEqual(900, _a1.Saldo);
            _a1.Doblarse();
            Assert.AreEqual(800, _a1.Saldo);

            _a0.IniciaMano(800);
            Assert.AreEqual(200, _a0.Saldo);
            _a0.RecibeCarta(new Carta(Carta.Valor.Jota, Carta.Palo.Corazones));
            _a0.RecibeCarta(new Carta(Carta.Valor.Nueve, Carta.Palo.Picas));
            Assert.Throws<Jugador.Excepcion>(() => _a0.Doblarse());
        }

        [Test()]
        public void EmpataTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a0.Empata());
            Assert.Throws<Jugador.Excepcion>(() => _a1.Empata());
            Assert.AreEqual(800, _a2.Saldo);
            _a2.Empata();
            Assert.AreEqual(1000, _a2.Saldo);
        }

        [Test()]
        public void GanaTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a0.Gana());
            Assert.Throws<Jugador.Excepcion>(() => _a1.Gana());

            Assert.AreEqual(900, _a1.Saldo);
            _a1.RecibeCarta(new Carta(Carta.Valor.Jota, Carta.Palo.Corazones));
            _a1.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Picas));
            _a1.Gana();
            Assert.AreEqual(1100, _a1.Saldo);

            Assert.AreEqual(800, _a2.Saldo);
            _a2.Gana();
            Assert.AreEqual(1300, _a2.Saldo); // Gana con BJ 3 a 2
        }

        [Test()]
        public void ToStringTest()
        {
            Assert.AreEqual("Susana", _a0.ToString());
        }
    }
}