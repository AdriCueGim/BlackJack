using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Croupier : Jugador
    {
        public Mazo MazoReparto { get; }
        public Mazo MazoRetirada { get; }
        private ManoCroupier _ManoCroupier
        {
            get
            {
                return Mano as ManoCroupier;
            }
        }
        public int NumeroBarajas 
        { 
            get
            {
                return 2;
            }
        }
        public int CartasEnReparto 
        { 
            get
            {
                return MazoReparto.NumeroCartas;
            }
        }
        public int CartasRetiradas
        {
            get
            {
                return MazoReparto.NumeroCartas;
            }
        }
        public override bool PuedePedirCarta
        {
            get
            {
                return false;
            }
        }
        public bool MazosInicializados 
        { 
            get
            {
                return CartasEnReparto > 0 || CartasRetiradas > 0;
            }
        }

        public Croupier()
        {
            Mano = null;
            MazoReparto = new Mazo();
            MazoRetirada = new Mazo();
        }

        public void MezclaMazoReparto()
        {
            if (ManoIniciada && CartasEnReparto == 52 * NumeroBarajas)
                MazoReparto.Mezcla();
        }

        public void AñadeBarajasAlMazoReparto()
        {
            if (ManoIniciada || MazosInicializados)
                throw new Excepcion("No se pueden añadir barajas porque la mano o los mazos ya se han inicializado.");
            while (MazoReparto.NumeroCartas < 52 * NumeroBarajas)
                MazoReparto.AñadeBaraja();
        }

        public void ReiniciaMazoRepartoConCartasRetiradas()
        {
            while (MazoRetirada.NumeroCartas > 0)
                MazoReparto.AñadeCarta(MazoRetirada.ExtraePrimera());
        }

        public void ReparteCarta(Jugador j)
        {
            j.RecibeCarta(MazoReparto.ExtraePrimera());
        }

        public void RetiraMano(Jugador j)
        {
            List<Carta> cartasJugador = new List<Carta>(j.FinalizaMano());
            for (int i = 0; i < cartasJugador.Count; i++)
                MazoRetirada.AñadeCarta(cartasJugador[i]);
        }

        public void GestionaFichasAlFinalizarMano(Apostador a)
        {
            if (!ManoIniciada || !a.ManoIniciada)
                throw new Excepcion("Alguna de las manos no ha sido iniciada");

            int ganador = _ManoCroupier.CompareTo(a.Mano);
            if (ganador > 0)
                a.Gana();
            else if (ganador == 0)
                a.Empata();
        }
        public void IniciaMano()
        {
            if (ManoIniciada)
                throw new Excepcion("La mano ya se había iniciado.");
            Mano = new ManoCroupier();
        }

        public override string ToString()
        {
            return "Croupier";
        }
    }
}
