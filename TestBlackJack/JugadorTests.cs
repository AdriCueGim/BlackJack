using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class JugadorTests
    {
        private Apostador _a;
        private Croupier _c;

        [SetUp]
        public void SetUp()
        {
            _a = new Apostador("Maria", 1000);
            _a.Silla = 0;
            _c = new Croupier();
        }

        [Test()]
        public void IniciaManoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a.IniciaMano(1001));
            _a.IniciaMano(100);
            _c.IniciaMano();
        }

        [Test()]
        public void RecibeCartaTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _a.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<Jugador.Excepcion>(() => _c.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            _a.IniciaMano(100);
            _c.IniciaMano();
            _a.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _c.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
        }

        [Test()]
        public void FinalizaManoTest()
        {
            _a.IniciaMano(100);
            _c.IniciaMano();
            _a.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _c.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _a.FinalizaMano()); // Finalizando una mano no cerrada
            Assert.Throws<ManoBlackJack.Excepcion>(() => _c.FinalizaMano()); // Finalizando una mano no cerrada
            _a.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles));
            _c.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Treboles));
            _a.FinalizaMano();
            _c.FinalizaMano();
        }

        [Test()]
        public void DisposeTest()
        {
            _a.IniciaMano(100);
            _a.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            Assert.Throws<Jugador.Excepcion>(() => _a.Dispose());
            _a.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles));
            Assert.Throws<Jugador.Excepcion>(() => _a.Dispose());
            _a.FinalizaMano();
            _a.Dispose();
        }
    }
}