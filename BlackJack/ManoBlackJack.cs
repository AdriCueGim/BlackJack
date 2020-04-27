using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BlackJack
{
    public abstract class ManoBlackJack : IEnumerable<Carta>, IComparable<ManoBlackJack>
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
                    if (puntosPosibles.Count == 0)
                        puntosMano = 0;
                    else
                        puntosMano = puntosPosibles[0];
                }
                else
                    puntosMano = puntosPosiblesQueNoSePasan[puntosPosiblesQueNoSePasan.Count - 1];
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
                    if (puntosPosibles.Count == 0)
                        texto = "0";
                    else
                        texto = $"{puntosPosibles[0]}";
                }
                else
                    if (puntosPosiblesQueNoSePasan[puntosPosiblesQueNoSePasan.Count - 1] == 21)
                        texto = "21";
                    else
                        for (int i = 0; i < puntosPosiblesQueNoSePasan.Count; i++)
                            texto += $"{puntosPosiblesQueNoSePasan[i] + (i + 1 != puntosPosiblesQueNoSePasan.Count ? "/" : "")}";
                return texto;
            }
        }

        public bool BlackJack
        {
            get
            {
                return Puntos == PUNTOS_MAXIMOS_BLACK_JACK && Cartas.Count == 2;
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
                    valorCarta = 3;
                    break;
                case Carta.Valor.Cuatro:
                    valorCarta = 4;
                    break;
                case Carta.Valor.Cinco:
                    valorCarta = 5;
                    break;
                case Carta.Valor.Seis:
                    valorCarta = 6;
                    break;
                case Carta.Valor.Siete:
                    valorCarta = 7;
                    break;
                case Carta.Valor.Ocho:
                    valorCarta = 8;
                    break;
                case Carta.Valor.Nueve:
                    valorCarta = 9;
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
            if (Puntos >= PuntosParaCerrarAutomaticamente)
                Cierra();
        }

        public List<Carta> Retira()
        {
            if (!Cerrada)
                throw new Excepcion("No se puede retirar si la mano no está cerrada.");
            List<Carta> mano = new List<Carta>(Cartas);
            Cartas = null;
            return mano;
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

        public IEnumerator<Carta> GetEnumerator()
        {
            return Cartas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Cartas.GetEnumerator();
        }

        public virtual int CompareTo(ManoBlackJack manoContrincante)
        {
            if (!Cerrada)
                throw new Excepcion("No se pueden comparar una mano que no está cerrada");
            int ganador = Puntos - manoContrincante.Puntos;
            if (ganador == 0 && !SePasa && !manoContrincante.SePasa)
                if (BlackJack && !manoContrincante.BlackJack)
                    ganador = 1;
                else if (!BlackJack && manoContrincante.BlackJack)
                    ganador = -1;
            return ganador;
        }
    }
}
