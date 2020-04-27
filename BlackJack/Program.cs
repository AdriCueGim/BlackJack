using System;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            //var vista = new VistaTest();
            //try
            //{
            //    Controlador controlador = new Controlador(new MesaBlackJack(), vista);
            //    controlador.EmpiezaJuego();
            //}
            //catch (Exception e)
            //{
            //    vista.MuestraMensaje(e.Message);
            //    Environment.Exit(-1);
            //}
            ManoCroupier croupier = new ManoCroupier();
            ManoApostador jugador1 = new ManoApostador(100);
            ManoApostador jugador2 = new ManoApostador(100);
            Console.WriteLine(jugador1.Puntos);
            jugador1.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Treboles));
            jugador1.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Picas));
            jugador1.AñadeCarta(new Carta(Carta.Valor.Siete, Carta.Palo.Diamantes));
            jugador2.AñadeCarta(new Carta(Carta.Valor.As, Carta.Palo.Corazones));
            jugador2.AñadeCarta(new Carta(Carta.Valor.Rey, Carta.Palo.Picas));
        }
    }
}
