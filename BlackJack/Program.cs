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
            Carta carta = new Carta(
                (Valor)Enum.Parse(typeof(Valor), "As"), 
                (Palo)0x04);
            Mazo mazo = new Mazo();
            mazo.AñadeBaraja();
            Console.WriteLine(mazo);
            Console.WriteLine(carta);

        }
    }
}
