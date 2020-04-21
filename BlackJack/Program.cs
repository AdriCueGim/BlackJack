using System;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            var vista = new VistaTest();
            try
            {
                Controlador controlador = new Controlador(new MesaBlackJack(), vista);
                controlador.EmpiezaJuego();
            }
            catch (Exception e)
            {
                vista.MuestraMensaje(e.Message);
                Environment.Exit(-1);
            }
        }
    }
}
