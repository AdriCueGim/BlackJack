using NUnit.Framework;
using System;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class ManoBlackJackTests
    {
        private ManoCroupier _mc0;
        private ManoCroupier _mc6o16__A_5;
        private ManoCroupier _mc6o16__A_3_2;
        private ManoCroupier _mc6o16o26__A_2_A_2;
        private ManoCroupier _mc17__2_2_6_7;
        private ManoCroupier _mc16__K_6;
        private ManoCroupier _mc17__Q_7;
        private ManoCroupier _mc18__J_8;
        private ManoCroupier _mc21__7_7_7;
        private ManoCroupier _mcBJ__A_K;
        private ManoCroupier _mc26__8_8_K_SePasa;

        private ManoApostador _ma0;
        private ManoApostador _ma6o16__A_5;
        private ManoApostador _ma6o16__A_3_2;
        private ManoApostador _ma6o16o26__A_2_A_2;
        private ManoApostador _ma18__A_4_3_10;
        private ManoApostador _ma17__2_2_6_7;
        private ManoApostador _ma16__K_6;
        private ManoApostador _ma17__Q_7;
        private ManoApostador _ma18__J_8;
        private ManoApostador _ma21__A_5_3_2;
        private ManoApostador _maBJ__A_K;
        private ManoApostador _ma26__8_8_K_SePasa;

        [SetUp]
        protected void SetUp()
        {
            _mc0 = new ManoCroupier();
            _mc6o16__A_5 = new ManoCroupier();
            _mc6o16__A_5.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mc6o16__A_5.AñadeCarta(new Carta(Carta.Valor.Cinco, Carta.Palo.Picas));

            _mc6o16__A_3_2 = new ManoCroupier();
            _mc6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mc6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Tres, Carta.Palo.Picas));
            _mc6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));

            _mc6o16o26__A_2_A_2 = new ManoCroupier();
            _mc6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mc6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));
            _mc6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Picas));
            _mc6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));

            _mc17__2_2_6_7 = new ManoCroupier();
            _mc17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));
            _mc17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));
            _mc17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Seis, Carta.Palo.Picas));
            _mc17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Corazones));

            _mc16__K_6 = new ManoCroupier();
            _mc16__K_6.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Corazones));
            _mc16__K_6.AñadeCarta(new Carta(Carta.Valor.Seis, Carta.Palo.Picas));

            _mc17__Q_7 = new ManoCroupier();
            _mc17__Q_7.AñadeCarta(new Carta(Carta.Valor.Reina, Carta.Palo.Corazones));
            _mc17__Q_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Picas));

            _mc18__J_8 = new ManoCroupier();
            _mc18__J_8.AñadeCarta(new Carta(Carta.Valor.Jota, Carta.Palo.Corazones));
            _mc18__J_8.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Picas));

            _mc21__7_7_7 = new ManoCroupier();
            _mc21__7_7_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Treboles));
            _mc21__7_7_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Picas));
            _mc21__7_7_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Diamantes));

            _mcBJ__A_K = new ManoCroupier();
            _mcBJ__A_K.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mcBJ__A_K.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Picas));

            _mc26__8_8_K_SePasa = new ManoCroupier();
            _mc26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Treboles));
            _mc26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Corazones));
            _mc26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Picas));

            // -----------------------------------------------------------------------------

            _ma0 = new ManoApostador(1000);
            _ma6o16__A_5 = new ManoApostador(1000);
            _ma6o16__A_5.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _ma6o16__A_5.AñadeCarta(new Carta(Carta.Valor.Cinco, Carta.Palo.Picas));

            _ma6o16__A_3_2 = new ManoApostador(1000);
            _ma6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _ma6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Tres, Carta.Palo.Picas));
            _ma6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));

            _ma6o16o26__A_2_A_2 = new ManoApostador(1000);
            _ma6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _ma6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));
            _ma6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Picas));
            _ma6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));

            _ma18__A_4_3_10 = new ManoApostador(1000);
            _ma18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _ma18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Cuatro, Carta.Palo.Picas));
            _ma18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Tres, Carta.Palo.Picas));
            _ma18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Diez, Carta.Palo.Corazones));

            _ma17__2_2_6_7 = new ManoApostador(1000);
            _ma17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));
            _ma17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Picas));
            _ma17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Seis, Carta.Palo.Picas));
            _ma17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Corazones));

            _ma16__K_6 = new ManoApostador(1000);
            _ma16__K_6.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Corazones));
            _ma16__K_6.AñadeCarta(new Carta(Carta.Valor.Seis, Carta.Palo.Picas));

            _ma17__Q_7 = new ManoApostador(1000);
            _ma17__Q_7.AñadeCarta(new Carta(Carta.Valor.Reina, Carta.Palo.Corazones));
            _ma17__Q_7.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Picas));

            _ma18__J_8 = new ManoApostador(1000);
            _ma18__J_8.AñadeCarta(new Carta(Carta.Valor.Jota, Carta.Palo.Corazones));
            _ma18__J_8.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Picas));

            _ma21__A_5_3_2 = new ManoApostador(1000);
            _ma21__A_5_3_2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _ma21__A_5_3_2.AñadeCarta(new Carta(Carta.Valor.Cinco, Carta.Palo.Treboles));
            _ma21__A_5_3_2.AñadeCarta(new Carta(Carta.Valor.Tres, Carta.Palo.Picas));
            _ma21__A_5_3_2.AñadeCarta(new Carta(Carta.Valor.Dos, Carta.Palo.Corazones));

            _maBJ__A_K = new ManoApostador(1000);
            _maBJ__A_K.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _maBJ__A_K.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Picas));

            _ma26__8_8_K_SePasa = new ManoApostador(1000);
            _ma26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Treboles));
            _ma26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Ocho, Carta.Palo.Corazones));
            _ma26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Picas));
        }

        [Test()]
        public void AñadeCartaAManoCroupierIgualOSuperiroA17Test()
        {
            ManoCroupier _mc18__A_4_3_10 = new ManoCroupier();
            _mc18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mc18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Cuatro, Carta.Palo.Picas));
            _mc18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Tres, Carta.Palo.Picas));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Diez, Carta.Palo.Corazones)));
            ManoCroupier _mc21__A_9_A = new ManoCroupier();
            _mc21__A_9_A.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            _mc21__A_9_A.AñadeCarta(new Carta(Carta.Valor.Nueve, Carta.Palo.Picas));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc21__A_9_A.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc21__7_7_7.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Treboles)));
        }

        [Test()]
        public void CierraTest()
        {
            _mc0.Cierra();
            _mc6o16__A_5.Cierra();
            _mc6o16__A_3_2.Cierra();
            _mc6o16o26__A_2_A_2.Cierra();
            _mc16__K_6.Cierra();

            _ma0.Cierra();
            _ma6o16__A_5.Cierra();
            _ma6o16__A_3_2.Cierra();
            _ma6o16o26__A_2_A_2.Cierra();
            _ma18__A_4_3_10.Cierra();
            _ma17__2_2_6_7.Cierra();
            _ma16__K_6.Cierra();
            _ma17__Q_7.Cierra();
            _ma18__J_8.Cierra();

            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc17__2_2_6_7.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc17__Q_7.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc18__J_8.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mcBJ__A_K.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc21__7_7_7.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc26__8_8_K_SePasa.Cierra());

            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma21__A_5_3_2.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _maBJ__A_K.Cierra());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma26__8_8_K_SePasa.Cierra());
        }

        [Test()]
        public void AñadeCartaTest()
        {
            _mc0.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _mc6o16__A_5.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _mc6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _mc6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _mc16__K_6.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));

            _ma0.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma6o16__A_5.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma6o16__A_3_2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma6o16o26__A_2_A_2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma18__A_4_3_10.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma16__K_6.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma17__Q_7.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));
            _ma18__J_8.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes));

            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc17__2_2_6_7.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc17__Q_7.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc18__J_8.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc21__7_7_7.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mcBJ__A_K.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));

            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma21__A_5_3_2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _maBJ__A_K.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma26__8_8_K_SePasa.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Diamantes)));
        }

        [Test()]
        public void CompruebaPuntosManoTest()
        {
            Assert.AreEqual(0, _mc0.Puntos);
            Assert.AreEqual(16, _mc6o16__A_5.Puntos);
            Assert.AreEqual(16, _mc6o16__A_3_2.Puntos);
            Assert.AreEqual(16, _mc6o16o26__A_2_A_2.Puntos);
            Assert.AreEqual(17, _mc17__2_2_6_7.Puntos);
            Assert.AreEqual(16, _mc16__K_6.Puntos);
            Assert.AreEqual(17, _mc17__Q_7.Puntos);
            Assert.AreEqual(18, _mc18__J_8.Puntos);
            Assert.AreEqual(21, _mc21__7_7_7.Puntos);
            Assert.AreEqual(21, _mcBJ__A_K.Puntos);
            Assert.AreEqual(26, _mc26__8_8_K_SePasa.Puntos);

            Assert.AreEqual(0, _ma0.Puntos);
            Assert.AreEqual(16, _ma6o16__A_5.Puntos);
            Assert.AreEqual(16, _ma6o16__A_3_2.Puntos);
            Assert.AreEqual(16, _ma6o16o26__A_2_A_2.Puntos);
            Assert.AreEqual(18, _ma18__A_4_3_10.Puntos);
            Assert.AreEqual(17, _ma17__2_2_6_7.Puntos);
            Assert.AreEqual(16, _ma16__K_6.Puntos);
            Assert.AreEqual(17, _ma17__Q_7.Puntos);
            Assert.AreEqual(18, _ma18__J_8.Puntos);
            Assert.AreEqual(21, _ma21__A_5_3_2.Puntos);
            Assert.AreEqual(21, _maBJ__A_K.Puntos);
            Assert.AreEqual(26, _ma26__8_8_K_SePasa.Puntos);
        }

        [Test()]
        public void CompruebaTextoPuntosManoTest()
        {
            Assert.AreEqual("0", _mc0.TextoPuntos);
            Assert.AreEqual("6/16", _mc6o16__A_5.TextoPuntos);
            Assert.AreEqual("6/16", _mc6o16__A_3_2.TextoPuntos);
            Assert.AreEqual("6/16", _mc6o16o26__A_2_A_2.TextoPuntos);
            Assert.AreEqual("17", _mc17__2_2_6_7.TextoPuntos);
            Assert.AreEqual("16", _mc16__K_6.TextoPuntos);
            Assert.AreEqual("17", _mc17__Q_7.TextoPuntos);
            Assert.AreEqual("18", _mc18__J_8.TextoPuntos);
            Assert.AreEqual("21", _mc21__7_7_7.TextoPuntos);
            Assert.AreEqual("21", _mcBJ__A_K.TextoPuntos);
            Assert.AreEqual("26", _mc26__8_8_K_SePasa.TextoPuntos);
                            
            Assert.AreEqual("0", _ma0.TextoPuntos);
            Assert.AreEqual("6/16", _ma6o16__A_5.TextoPuntos);
            Assert.AreEqual("6/16", _ma6o16__A_3_2.TextoPuntos);
            Assert.AreEqual("6/16", _ma6o16o26__A_2_A_2.TextoPuntos);
            Assert.AreEqual("18", _ma18__A_4_3_10.TextoPuntos);
            Assert.AreEqual("17", _ma17__2_2_6_7.TextoPuntos);
            Assert.AreEqual("16", _ma16__K_6.TextoPuntos);
            Assert.AreEqual("17", _ma17__Q_7.TextoPuntos);
            Assert.AreEqual("18", _ma18__J_8.TextoPuntos);
            Assert.AreEqual("21", _ma21__A_5_3_2.TextoPuntos);
            Assert.AreEqual("21", _maBJ__A_K.TextoPuntos);
            Assert.AreEqual("26", _ma26__8_8_K_SePasa.TextoPuntos);
        }

        [Test()]
        public void RetiraTest()
        {
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc0.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc6o16__A_5.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc6o16__A_3_2.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc6o16o26__A_2_A_2.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc16__K_6.Retira());

            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma0.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16__A_5.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16__A_3_2.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16o26__A_2_A_2.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma18__A_4_3_10.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma17__2_2_6_7.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma16__K_6.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma17__Q_7.Retira());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma18__J_8.Retira());

            Assert.AreEqual(4, _mc17__2_2_6_7.Retira().Count);
            Assert.AreEqual(2, _mc17__Q_7.Retira().Count);
            Assert.AreEqual(2, _mc18__J_8.Retira().Count);
            Assert.AreEqual(3, _mc21__7_7_7.Retira().Count);
            Assert.AreEqual(2, _mcBJ__A_K.Retira().Count);
            Assert.AreEqual(3, _mc26__8_8_K_SePasa.Retira().Count);

            Assert.AreEqual(4, _ma21__A_5_3_2.Retira().Count);
            Assert.AreEqual(2, _maBJ__A_K.Retira().Count);
            Assert.AreEqual(3, _ma26__8_8_K_SePasa.Retira().Count);

        }

        [Test()]
        public void DoblarTest()
        {
            _ma6o16__A_5.Doblar();
            _ma16__K_6.Doblar();
            _ma17__Q_7.Doblar();
            _ma18__J_8.Doblar();

            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma0.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _maBJ__A_K.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16__A_3_2.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16o26__A_2_A_2.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma18__A_4_3_10.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma17__2_2_6_7.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma21__A_5_3_2.Doblar());
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma26__8_8_K_SePasa.Doblar());
        }

        [Test()]
        public void RecorreCartasManoTest()
        {
            int i = 0;
            foreach (var c in _ma18__A_4_3_10)
            {
                c.ToString();
                i++;
            }
            Assert.AreEqual(4, i);
        }

        [Test()]
        public void PuedeRecibirCartaTest()
        {
            Assert.IsTrue(_mc0.SePuedeRecibirCarta);
            Assert.IsTrue(_mc6o16__A_3_2.SePuedeRecibirCarta);
            Assert.IsTrue(_mc6o16o26__A_2_A_2.SePuedeRecibirCarta);
            Assert.IsTrue(_mc16__K_6.SePuedeRecibirCarta);
            Assert.IsFalse(_mc17__2_2_6_7.SePuedeRecibirCarta);
            Assert.IsFalse(_mc18__J_8.SePuedeRecibirCarta);
            Assert.IsFalse(_mc21__7_7_7.SePuedeRecibirCarta);
            Assert.IsFalse(_mcBJ__A_K.SePuedeRecibirCarta);
            Assert.IsFalse(_mc26__8_8_K_SePasa.SePuedeRecibirCarta);

            Assert.IsTrue(_ma0.SePuedeRecibirCarta);
            Assert.IsTrue(_ma6o16__A_5.SePuedeRecibirCarta);
            Assert.IsTrue(_ma6o16o26__A_2_A_2.SePuedeRecibirCarta);
            Assert.IsTrue(_ma18__A_4_3_10.SePuedeRecibirCarta);
            Assert.IsTrue(_ma17__2_2_6_7.SePuedeRecibirCarta);
            Assert.IsTrue(_ma16__K_6.SePuedeRecibirCarta);
            Assert.IsFalse(_ma21__A_5_3_2.SePuedeRecibirCarta);
            Assert.IsFalse(_maBJ__A_K.SePuedeRecibirCarta);
            Assert.IsFalse(_ma26__8_8_K_SePasa.SePuedeRecibirCarta);
        }

        [Test()]
        public void SePasaTest()
        {
            Assert.IsFalse(_mc0.SePasa);
            Assert.IsFalse(_mc6o16__A_3_2.SePasa);
            Assert.IsFalse(_mc6o16o26__A_2_A_2.SePasa);
            Assert.IsFalse(_mc17__2_2_6_7.SePasa);
            Assert.IsFalse(_mc16__K_6.SePasa);
            Assert.IsFalse(_mc18__J_8.SePasa);
            Assert.IsFalse(_mc21__7_7_7.SePasa);
            Assert.IsFalse(_mcBJ__A_K.SePasa);
            Assert.IsTrue(_mc26__8_8_K_SePasa.SePasa);

            Assert.IsFalse(_ma0.SePasa);
            Assert.IsFalse(_ma6o16__A_5.SePasa);
            Assert.IsFalse(_ma6o16o26__A_2_A_2.SePasa);
            Assert.IsFalse(_ma18__A_4_3_10.SePasa);
            Assert.IsFalse(_ma17__2_2_6_7.SePasa);
            Assert.IsFalse(_ma16__K_6.SePasa);
            Assert.IsFalse(_ma21__A_5_3_2.SePasa);
            Assert.IsFalse(_maBJ__A_K.SePasa);            
            Assert.IsTrue(_ma26__8_8_K_SePasa.SePasa);
        }

        [Test()]
        public void CompareToTest()
        {
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc0.CompareTo(_ma21__A_5_3_2));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc6o16__A_3_2.CompareTo(_ma21__A_5_3_2));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _mc16__K_6.CompareTo(_ma16__K_6));

            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma0.CompareTo(_mc18__J_8));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma6o16__A_3_2.CompareTo(_mc18__J_8));
            Assert.Throws<ManoBlackJack.Excepcion>(() => _ma16__K_6.CompareTo(_mc16__K_6));

            _ma18__A_4_3_10.Cierra();
            _ma17__2_2_6_7.Cierra();
            _ma18__J_8.Cierra();

            Assert.IsTrue(_mc17__2_2_6_7.CompareTo(_ma18__A_4_3_10) < 0);
            Assert.IsTrue(_mc17__Q_7.CompareTo(_ma17__2_2_6_7) == 0);
            Assert.IsTrue(_mc18__J_8.CompareTo(_ma17__2_2_6_7) > 0);
            Assert.IsTrue(_mc21__7_7_7.CompareTo(_ma21__A_5_3_2) == 0);
            Assert.IsTrue(_mc21__7_7_7.CompareTo(_maBJ__A_K) < 0);
            Assert.IsTrue(_mcBJ__A_K.CompareTo(_ma21__A_5_3_2) > 0);
            Assert.IsTrue(_mc26__8_8_K_SePasa.CompareTo(_ma26__8_8_K_SePasa) > 0);

            Assert.IsTrue(_ma18__A_4_3_10.CompareTo(_mc17__2_2_6_7) > 0);
            Assert.IsTrue(_ma17__2_2_6_7.CompareTo(_mc17__2_2_6_7) == 0);
            Assert.IsTrue(_ma18__J_8.CompareTo(_mcBJ__A_K) < 0);
            Assert.IsTrue(_ma21__A_5_3_2.CompareTo(_mcBJ__A_K) < 0);
            Assert.IsTrue(_ma21__A_5_3_2.CompareTo(_mc21__7_7_7) == 0);
            Assert.IsTrue(_maBJ__A_K.CompareTo(_mcBJ__A_K) == 0);
            Assert.IsTrue(_ma26__8_8_K_SePasa.CompareTo(_mc26__8_8_K_SePasa) < 0);
        }
    }
}