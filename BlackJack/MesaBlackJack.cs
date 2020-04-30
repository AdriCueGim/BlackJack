using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class MesaBlackJack
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

        public Croupier _Croupier { get; }
        private List<Apostador> Apostadores { get; }
        public int MinimoJugadores
        {
            get
            {
                return 2;
            }
        }
        public int MaximoJugadores 
        { 
            get 
            { 
                return 4; 
            } 
        }
        public int NumeroApostadores 
        { 
            get
            {
                return Apostadores.Count;
            }
        }
        public int MinimoCartasParaNuevaMano 
        { 
            get
            {
                return (NumeroApostadores + 1) * 5;
            }
        }
        public Apostador this[int i] 
        {
            get
            {
                if (i > NumeroApostadores - 1 || i < 0)
                    throw new Excepcion("El jugador del índice i no existe.");
                return Apostadores[i];
            }
        }

        public MesaBlackJack()
        {
            _Croupier = new Croupier();
            Apostadores = new List<Apostador>();
        }

        private bool EstaEnLaMesa(Apostador apostador)
        {
            bool esta = false;
            for (int i = 0; i < NumeroApostadores && !esta; i++)
                esta = apostador == Apostadores[i];
            return esta;
        }

        public void Sienta(Apostador a)
        {
            if (NumeroApostadores == MaximoJugadores)
                throw new Excepcion("La mesa ya está llena");
            if (EstaEnLaMesa(a))
                throw new Excepcion($"{a.Nombre} ya está en la mesa");
            Apostadores.Add(a);
            a.Silla = Apostadores.IndexOf(a);
        }

        public void Levanta(Apostador a)
        {
            if (!EstaEnLaMesa(a))
                throw new Excepcion($"{a.Nombre} no está en la mesa");
            Apostadores.Remove(a);
            a.Silla = -1;
            a.Dispose();
        }
    }
}
