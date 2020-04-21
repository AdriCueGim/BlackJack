using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Carta
    {
        public enum Palo
        {
            Corazones = 0x03, Diamantes = 0x04, 
            Treboles = 0x05, Picas = 0x06
        }
        public enum Valor
        {
            As, Dos, Tres, Cuatro, Cinco, Seis, 
            Siete, Ocho, Nueve, Diez, Jota, Reina, Rey
        }
        public enum Color
        {
            Rojo, Negro
        }

        public Valor _Valor { get; }
        public string SimboloValor
        {
            get
            {
                string simbolo = "";
                switch (_Valor)
                {
                    case Valor.As:
                        simbolo = "A";
                        break;
                    case Valor.Dos:
                        simbolo = "2";
                        break;
                    case Valor.Tres:
                        simbolo = "3";
                        break;
                    case Valor.Cuatro:
                        simbolo = "4";
                        break;
                    case Valor.Cinco:
                        simbolo = "5";
                        break;
                    case Valor.Seis:
                        simbolo = "6";
                        break;
                    case Valor.Siete:
                        simbolo = "7";
                        break;
                    case Valor.Ocho:
                        simbolo = "8";
                        break;
                    case Valor.Nueve:
                        simbolo = "9";
                        break;
                    case Valor.Diez:
                        simbolo = "10";
                        break;
                    case Valor.Jota:
                        simbolo = "J";
                        break;
                    case Valor.Reina:
                        simbolo = "Q";
                        break;
                    case Valor.Rey:
                        simbolo = "K";
                        break;
                }
                return simbolo;
            }
        }
        public Palo _Palo { get; }
        public char SimboloPalo
        {
            get
            {
                return (char) _Palo;
            }
        }
        public Color _Color { get; }

        public Carta(Valor valor, Palo palo)
        {
            _Valor = valor;
            _Palo = palo;
        }

        public override string ToString()
        {
            return $"{SimboloValor} {SimboloPalo}";
        }
    }
}
