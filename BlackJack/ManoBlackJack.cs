using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public abstract class ManoBlackJack
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

        private int PUNTOS_MAXIMOS_BLACK_JACK { get { return 21; } }
        protected List<Carta> Cartas { get; set; }
        public bool Cerrada { get; set; }
        public abstract int PuntosParaCerrarAutomaticamente { get; }
        public int Puntos 
        { 
            get
            {
                int puntosMano;
                List<int> puntosPosiblesQueNoSePasan = PuntuacionesPosiblesQueNoSePasan();
                if (puntosPosiblesQueNoSePasan.Count == 0)
                {
                    List<int> puntosPosibles = PuntuacionesPosibles();
                    puntosMano = puntosPosibles[0];
                }
                else
                    puntosMano = puntosPosiblesQueNoSePasan[puntosPosiblesQueNoSePasan.Count];
                return puntosMano;
            }
        }

        public string TextoPuntos
        {
            get
            {
                string texto = "";
                List<int> puntosPosiblesQueNoSePasan = PuntuacionesPosiblesQueNoSePasan();
                if (puntosPosiblesQueNoSePasan.Count == 0)
                {
                    List<int> puntosPosibles = PuntuacionesPosibles();
                    texto = $"{puntosPosibles[0]}";
                }
                else
                    for (int i = 0; i < puntosPosiblesQueNoSePasan.Count; i++)
                        texto = $"{puntosPosiblesQueNoSePasan[i] + (i + 1 != puntosPosiblesQueNoSePasan.Count ? " / " : "")}";
                return texto;
            }
        }

        public bool BlackJack
        {
            get
            {
                return Puntos == PUNTOS_MAXIMOS_BLACK_JACK;
            }
        }

        public bool SePasa
        {
            get
            {
                return Puntos > PUNTOS_MAXIMOS_BLACK_JACK;
            }
        }

        public bool SePuedeRecibirCarta
        {
            get
            {
                return !Cerrada && Puntos < PuntosParaCerrarAutomaticamente;
            }
        }

        public ManoBlackJack()
        {
            Cartas = new List<Carta>();
            Cerrada = false;
        }

        protected int ValorCarta(Carta.Valor valor, bool asValeOnce = true)
        {
            int valorCarta;
            switch (valor)
            {
                case Carta.Valor.As:
                    valorCarta = asValeOnce ? 11 : 1;
                    break;
                case Carta.Valor.Dos:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Tres:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Cuatro:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Cinco:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Seis:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Siete:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Ocho:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Nueve:
                    valorCarta = 2;
                    break;
                case Carta.Valor.Diez:
                case Carta.Valor.Jota:
                case Carta.Valor.Reina:
                case Carta.Valor.Rey:
                    valorCarta = 10;
                    break;
                default:
                    valorCarta = 0;
                    break;
            }
            return valorCarta;
        }

        private List<int> PuntuacionesPosibles()
        {
            List<int> puntuacionesPosibles =  new List<int>();
            int valor;
            foreach (Carta carta in Cartas)
            {
                if (carta._Valor == Carta.Valor.As)
                {
                    if (puntuacionesPosibles.Count == 0)
                    {
                        valor = ValorCarta(carta._Valor, false);
                        puntuacionesPosibles.Add(valor);
                        valor = ValorCarta(carta._Valor, true);
                        puntuacionesPosibles.Add(valor);
                    }
                    else
                    {
                        List<int> aux = new List<int>();
                        for (int i = 0; i < puntuacionesPosibles.Count; i++)
                        {
                            valor = ValorCarta(carta._Valor, false);
                            aux.Add(puntuacionesPosibles[i] + valor);
                            valor = ValorCarta(carta._Valor, true);
                            aux.Add(puntuacionesPosibles[i] + valor);
                        }
                        aux.Sort();
                        int numeroAnterior = 0;
                        for (int i = 0; i < aux.Count; i++)
                        {
                            if (aux[i] == numeroAnterior)
                                aux.Remove(numeroAnterior);
                            numeroAnterior = aux[i];
                        }
                        puntuacionesPosibles = aux;
                    }
                }
                else
                {
                    valor = ValorCarta(carta._Valor);
                    if (puntuacionesPosibles.Count == 0)
                        puntuacionesPosibles.Add(valor);
                    else
                        for (int i = 0; i < puntuacionesPosibles.Count; i++)
                            puntuacionesPosibles[i] += valor;
                }
            }
            puntuacionesPosibles.Sort();
            return puntuacionesPosibles;
        }
        
        private List<int> PuntuacionesPosiblesQueNoSePasan()
        {
            List<int> puntuacionesPosibles = PuntuacionesPosibles();
            for (int i = 0; i < puntuacionesPosibles.Count; i++)
                if (puntuacionesPosibles[i] > PUNTOS_MAXIMOS_BLACK_JACK)
                    puntuacionesPosibles.Remove(puntuacionesPosibles[i]);
            return puntuacionesPosibles;
        }

        public void Cierra()
        {
            if (Cerrada)
                throw new Excepcion("La mano ya estaba cerrada.");
            Cerrada = true;
        }

        public void AñadeCarta(Carta carta)
        {
            if (Cerrada)
                throw new Excepcion("No se pueden añadir cartas, la mano estaba cerrada.");
            Cartas.Add(carta);
            if (Puntos > PuntosParaCerrarAutomaticamente)
                Cierra();
        }

        public override string ToString()
        {
            string salida = $"Cerrada: {(Cerrada ? "Si": "No")}\n" +
                   $"Puntos: {TextoPuntos} | {Puntos}\n" +
                   $"Se pasa: {(SePasa ? "Si" : "No")}\n" +
                   $"Black Jack: {(BlackJack ? "Si" : "No")}\n" +
                   $"Se puede recibir carta: {(SePuedeRecibirCarta ? "Si" : "No")}";
            salida += "\nLista de cartas:";
            for (int i = 0; i < Cartas.Count; i++)
                salida += $"{Cartas[i]}";
            return salida;
        }
    }
}
