using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Apostador : Jugador
    {
        public enum Accion
        {
            Plantarse, Doblarse, Carta
        }

        public string Nombre { get; }
        private Accion Estado { get; set; }
        public int Saldo { get; private set; }
        public int Silla { get; set; }
        public override bool PuedePedirCarta
        {
            get
            {
                bool puedePedir = _ManoApostador.SePuedeRecibirCarta;
                if (Estado == Accion.Doblarse && PuedeDoblarse)
                    puedePedir = true;
                else if (Estado == Accion.Plantarse)
                    puedePedir = false;
                return puedePedir;
            }
        }
        public bool PuedeDoblarse
        {
            get
            {
                return ManoIniciada && _ManoApostador.Apuesta * 2 <= Saldo &&
                       _ManoApostador.SePuedeDoblarApuesta;
            }
        }
        private ManoApostador _ManoApostador
        {
            get
            {
                return Mano as ManoApostador;
            }
        }

        public Apostador(string nombre, int saldo)
        {
            if (saldo < 0)
                throw new Excepcion("El saldo no puede ser negativo.");
            Mano = null;
            Nombre = nombre;
            Saldo = saldo;
            Silla = -1;
        }

        public void Plantarse()
        {
            if (Estado == Accion.Plantarse)
                throw new Excepcion($"El jugador {Nombre} ya se había plantado");
            if (_ManoApostador.Cerrada)
                throw new Excepcion($"la mano de {Nombre} ya se había cerrado");
            _ManoApostador.Cierra();
            Estado = Accion.Plantarse;
        }

        public void Doblarse()
        {
            if (Estado == Accion.Doblarse)
                throw new Excepcion($"El jugador {Nombre} ya se había doblado");
            if (Estado == Accion.Plantarse)
                throw new Excepcion($"El jugador {Nombre} se había plantado");
            if (!PuedeDoblarse)
                throw new Excepcion($"El jugador {Nombre} no se puede doblar");
            Estado = Accion.Doblarse;
            Saldo -= _ManoApostador.Apuesta;
            _ManoApostador.Doblar();
        }

        private void CompruebaMano()
        {
            if (!ManoIniciada)
                throw new Excepcion($"El jugador {Nombre} no tiene la mano iniciada");
            if (!_ManoApostador.Cerrada)
                throw new Excepcion($"El jugador {Nombre} no tiene la mano cerrada");
        }

        public void Empata()
        {
            CompruebaMano();
            Saldo += _ManoApostador.Apuesta;
        }

        public void Gana()
        {
            CompruebaMano();
            if (_ManoApostador.BlackJack)
                Saldo += _ManoApostador.Apuesta / 2 * 3 + _ManoApostador.Apuesta;
            else
                Saldo += _ManoApostador.Apuesta * 2;
        }

        public void IniciaMano(int apuesta)
        {
            if (ManoIniciada)
                throw new Excepcion($"La mano de {Nombre} ya se había iniciado");
            if (Saldo < apuesta)
                throw new Excepcion($"El saldo de {Nombre} ({Saldo}) no es suficiente para apostar {apuesta}");
            if (Silla == -1)
                throw new Excepcion($"El jugador {Nombre} no se ha sentado aún");
            Mano = new ManoApostador(apuesta);
            Saldo -= apuesta;
            Estado = Accion.Carta;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
