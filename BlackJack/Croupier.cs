using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Croupier : Jugador
    {
        private Mazo MazoReparto { get; }
        private Mazo MazoRetirada { get; }
        private int NumeroBarajas { get; }
        public int CartasEnReparto { get; }
        public int CartasRetiradas { get; }
        public override bool PuedePedirCarta
        {
            get
            {
                return false;
            }
        }
        public bool MazosInicializados { get; }

        public Croupier()
        {

        }

        public void MezclaMazoReparto()
        {

        }

        public void AñadeBarajasAlMazoReparto()
        {

        }

        public void ReiniciaMazoRepartoConCartasRetiradas()
        {

        }

        public void ReparteCarta(Jugador j)
        {

        }

        public void RetiraMano(Jugador j)
        {

        }

        public void GestionaFichasAlFinalizarMano(Apostador a)
        {

        }
        public void IniciaMano()
        {

        }

        public override string ToString()
        {
            return "Croupier";
        }
    }
}
