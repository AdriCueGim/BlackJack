using System;
using static BlackJack.Carta;

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
            Mazo mazo = new Mazo();
            mazo.AñadeBaraja();
            Console.WriteLine(mazo);
            mazo.Mezcla();
            Console.WriteLine(mazo);
        }
    }
}
