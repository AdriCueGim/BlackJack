using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class Jugador : IDisposable
    {
        public class Excepcion : Exception
        {
            public Excepcion(string message) : base(message)
            {
            }
            public Excepcion(string message, Exception innerException) : base(message, innerException)
            {
            }
        }

        public ManoBlackJack Mano { get; protected set; }
        public abstract bool PuedePedirCarta { get; }
        public bool ManoIniciada 
        { 
            get
            {
                return Mano != null;
            }
        }
        public bool PuedeRecibirCarta 
        { 
            get
            {
                return ManoIniciada && !Mano.Cerrada;
            }
        }

        protected Jugador()
        {
        }

        public void RecibeCarta(Carta c)
        {
            if (!ManoIniciada)
                throw new Excepcion("La mano no está iniciada, no se puede recibir carta.");
            if (Mano.Cerrada)
                throw new Excepcion("La mano está cerrada, no se puede recibir carta.");
            Mano.AñadeCarta(c);
        }

        public IEnumerable<Carta> FinalizaMano()
        {
            if (!ManoIniciada)
                throw new Excepcion("La mano no está iniciada, no se puede finalizar mano.");
            if (Mano.Cerrada)
                throw new Excepcion("La mano no está cerrada, no se puede finalizar.");
            List<Carta> mano = new List<Carta>(Mano);
            Mano = null;
            return mano;
        }

        public void Dispose()
        {
            if (ManoIniciada)
                throw new Excepcion("No se puede destruir el objeto porque la mano está iniciada");
            Mano = null;
        }
    }
}
