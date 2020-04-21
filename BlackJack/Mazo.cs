using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Mazo : IEnumerable<Carta>
    {
        private LinkedList<Carta> Cartas { get; set; }
        public int NumeroCartas 
        { 
            get
            { 
                return Cartas.Count; 
            } 
        }
        public Mazo()
        {
            Cartas = new LinkedList<Carta>();
        }

        public void AñadeBaraja()
        {

        }

        public void AñadeCarta(Carta carta)
        {
            Cartas.AddLast(carta);
        }

        public Carta ExtraePrimera()
        {
            Carta primera = Cartas.First.Value;
            Cartas.RemoveFirst();
            return primera;
        }

        public IEnumerator<Carta> GetEnumerator()
        {
            return Cartas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cartas.GetEnumerator();
        }
    }
}
