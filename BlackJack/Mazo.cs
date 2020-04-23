using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static BlackJack.Carta;

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
            Palo palo = (Palo)Enum.Parse(typeof(Palo), "Corazones");
            Valor valor = 0;
            for (int i = 0; i < 4; i++, palo += 1)
            {
                for (int j = 0; j < 13; j++, valor += 1)
                    AñadeCarta(new Carta(valor, palo));
                valor = 0;
            }
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

        public override string ToString()
        {
            string cadena = "Lista de cartas del mazo:\n";

            foreach (var carta in Cartas)
            {
                cadena += $"{carta} ";
            }

            return cadena;
        }

        public void Mezcla()
        {
            Carta[] cartas = new Carta[Cartas.Count];
            if (cartas.Length == 0)
                throw new Exception("No hay cartas en el mazo.");
            Cartas.CopyTo(cartas, 0);
            // Método incompleto.
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
