using NUnit.Framework;
using BlackJack;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Tests
{
    [TestFixture()]
    public class MesaBlackJackTests
    {
        private MesaBlackJack _mesa;
        private Apostador _a0, _a1, _a2, _a3, _a4;

        [SetUp]
        public void SetUp()
        {
            _mesa = new MesaBlackJack();
            _a0 = new Apostador("Susana", 1000);
            _a1 = new Apostador("Maria", 1000);
            _a2 = new Apostador("Susana", 1000);
            _a3 = new Apostador("Juan", 1000);
            _a4 = new Apostador("Pepe", 1000);
        }


        [Test()]
        public void SientaTest()
        {
            Assert.AreEqual(0, _mesa.NumeroApostadores);
            _mesa.Sienta(_a0);
            _mesa.Sienta(_a1);
            Assert.Throws<MesaBlackJack.Excepcion>(() => _mesa.Sienta(_a0));
            _mesa.Sienta(_a2);
            _mesa.Sienta(_a3);
            Assert.Throws<MesaBlackJack.Excepcion>(() => _mesa.Sienta(_a4));
            Assert.AreEqual(4, _mesa.NumeroApostadores);
        }

        [Test()]
        public void LevantaTest()
        {
            _mesa.Sienta(_a0);
            Assert.AreEqual(1, _mesa.NumeroApostadores);
            _mesa.Levanta(_a0);
            Assert.AreEqual(0, _mesa.NumeroApostadores);
            Assert.Throws<MesaBlackJack.Excepcion>(() => _mesa.Levanta(_a0));
            Assert.Throws<MesaBlackJack.Excepcion>(() => _mesa.Levanta(_a1));
        }

        [Test()]
        public void IndizadorAJugadorEnMesaTest()
        {
            _mesa.Sienta(_a0);
            _mesa.Sienta(_a1);
            _mesa.Sienta(_a2);
            Assert.NotNull(_mesa[1]);
            Assert.NotNull(_mesa[2]);
            Assert.Throws<MesaBlackJack.Excepcion>(() => Assert.NotNull(_mesa[3]));
        }
    }
}