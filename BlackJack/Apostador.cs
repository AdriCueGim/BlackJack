using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Apostador : Jugador
    {
        public enum Accion 
        { 
            Plantarse, Doblarse, Carta 
        }

        public string Nombre { get; }
        public int Saldo { get; private set; }
        public override bool PuedePedirCarta
        {
            get
            {
                return true;
            }
        }
        public bool PuedeDoblarse { get; }
        private ManoApostador _ManoApostador { get; }

        public Apostador(string nombre, int saldo)
        {
            Nombre = nombre;
            Saldo = saldo;
        }

        public void Plantarse()
        {

        }

        public void Doblarse()
        {

        }

        public void Empata()
        {

        }

        public void Gana()
        {

        }

        public void IniciaMano(int apuesta)
        {

        }

        public override string ToString()
        {
            
        }
    }
}
