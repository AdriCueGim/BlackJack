using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class ManoCroupier : ManoBlackJack
    {
        public override int PuntosParaCerrarAutomaticamente
        { 
            get
            {
                return 17;
            }
        }

        public override int CompareTo(ManoBlackJack manoContrincante)
        {
            if (!Cerrada || !manoContrincante.Cerrada)
                throw new Excepcion("No se puede comparar una mano que no esté cerrada");
            int ganador = Puntos - manoContrincante.Puntos;
            if (SePasa && !manoContrincante.SePasa)
                ganador = -1;
            else if (SePasa && manoContrincante.SePasa)
                ganador = 1;
            else if (ganador == 0 && !SePasa && !manoContrincante.SePasa)
                if (BlackJack && !manoContrincante.BlackJack)
                    ganador = 1;
                else if (!BlackJack && manoContrincante.BlackJack)
                    ganador = -1;
            return ganador;
        }
    }
}
