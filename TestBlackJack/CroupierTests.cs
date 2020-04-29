using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class CroupierTests
    {

        private Apostador _a0, _a1, _a2;
        private Croupier _c0, _c1, _c2;

        [SetUp]
        public void SetUp()
        {
            _a0 = new Apostador("Susana", 1000);
            _a0.Silla = 0;

            _a1 = new Apostador("Maria", 1000);
            _a1.Silla = 1;
            _a1.IniciaMano(100);
            _a1.RecibeCarta(new Carta(Carta.Valor.Nueve, Carta.Palo.Diamantes));

            _a2 = new Apostador("Juan", 1000);
            _a2.Silla = 2;
            _a2.IniciaMano(200);
            _a2.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _a2.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles));

            _c0 = new Croupier();
            _c1 = new Croupier();
            _c1.IniciaMano();
            _c1.RecibeCarta(new Carta(Carta.Valor.Nueve, Carta.Palo.Diamantes));

            _c2 = new Croupier();
            _c2.IniciaMano();
            _c2.RecibeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _c2.RecibeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles));
        }

        [Test()]
        [MaxTime(2000)]
        public void AñadeBajajasAlMazoRepartoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _c1.AñadeBajajasAlMazoReparto());
            Assert.Throws<Jugador.Excepcion>(() => _c2.AñadeBajajasAlMazoReparto());
            _c0.AñadeBajajasAlMazoReparto();
        }

        [Test()]
        [MaxTime(2000)]
        public void MezclaMazoRepartoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _c1.MezclaMazoReparto());
            Assert.Throws<Jugador.Excepcion>(() => _c2.MezclaMazoReparto());

            Assert.Throws<Jugador.Excepcion>(() => _c0.MezclaMazoReparto());
            _c0.AñadeBajajasAlMazoReparto();
            _c0.MezclaMazoReparto();
        }

         [Test()]
        public void ReparteCartaTest()
        {
            Assert.Throws<System.Exception>(() => _c0.ReparteCarta(_a1));
            Assert.Throws<System.Exception>(() => _c0.ReparteCarta(_c1));

            _c0.AñadeBajajasAlMazoReparto();

            _c0.ReparteCarta(_a1);
            Assert.Throws<Jugador.Excepcion>(() => _c0.ReparteCarta(_a0));
            Assert.Throws<Jugador.Excepcion>(() => _c0.ReparteCarta(_a2));

            _c0.ReparteCarta(_c1);
            Assert.Throws<Jugador.Excepcion>(() => _c0.ReparteCarta(_c0));
            Assert.Throws<Jugador.Excepcion>(() => _c0.ReparteCarta(_c2));
        }

        [Test()]
        public void RetiraManoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _c0.RetiraMano(_a0));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _c0.RetiraMano(_a1));
            Assert.Throws<Jugador.Excepcion>(() => _c0.RetiraMano(_c0));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _c0.RetiraMano(_c1));
            Assert.AreEqual(0, _c0.CartasRetiradas);
            _c0.RetiraMano(_a2);
            _c0.RetiraMano(_c2);
            Assert.AreEqual(4, _c0.CartasRetiradas);
        }

        [Test()]
        [MaxTime(2000)]
        public void ReiniciaMazoRepartoConCartasRetiradasTest()
        {
            _c0.RetiraMano(_a2);
            _c0.RetiraMano(_c2);
            _c0.ReiniciaMazoRepartoConCartasRetiradas();
        }

        [Test()]
        public void GestionaFichasAlFinalizarManoTest()
        {
            Assert.Throws<Jugador.Excepcion>(() => _c0.GestionaFichasAlFinalizarMano(_a0));
            Assert.Throws<Jugador.Excepcion>(() => _c1.GestionaFichasAlFinalizarMano(_a1));
            Assert.Throws<Jugador.Excepcion>(() => _c2.GestionaFichasAlFinalizarMano(_a1));
            _c2.GestionaFichasAlFinalizarMano(_a2);
        }

        [Test()]
        public void ToStringTest()
        {
            Assert.AreEqual("Croupier", _c0.ToString());
        }
    }
}