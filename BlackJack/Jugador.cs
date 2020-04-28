using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class Jugador
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

        }

        public IEnumerable<Carta> FinalizaMano()
        {
            
        }

        public void Dispose()
        {

        }
    }
}
