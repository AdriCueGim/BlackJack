using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class ManoApostador : ManoBlackJack
    {
        public int Apuesta { get; private set; }
        public override int PuntosParaCerrarAutomaticamente 
        {
            get
            {
                return 21;
            }
        }
        public bool SePuedeDoblarApuesta 
        {
            get
            {
                return Cartas.Count == 2 && !BlackJack;
            }
        }

        public ManoApostador(int apuesta)
        {
            Apuesta = apuesta;
        }

        public void Doblar()
        {
            if (!SePuedeDoblarApuesta)
                throw new Excepcion("No se puede doblar.");
            Apuesta *= 2;
        }

        public override int CompareTo(ManoBlackJack manoContrincante)
        {
            if (!Cerrada)
                throw new Excepcion("No se pueden comparar una mano que no está cerrada");
            int ganador = Puntos - manoContrincante.Puntos;
            if (SePasa)
                ganador = -1;
            else if (ganador == 0 && !SePasa && !manoContrincante.SePasa)
                if (BlackJack && !manoContrincante.BlackJack)
                    ganador = 1;
                else if (!BlackJack && manoContrincante.BlackJack)
                    ganador = -1;
            return ganador;
        }
    }
}
