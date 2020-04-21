using System;
using System.Drawing;
using System.Threading;

namespace BlackJack
{
    public class VistaTest : IVista
    {
        private int Filas { get => 24; }
        private int Columnas { get => 80; }
        private int SeparacionSillas { get => 5; }
        private int FilaInicioCroupier { get => 0; }
        private int FilaMensajes { get => Filas - 2; }
        private int AnchoSillaJugador { get; set; }
        private int FilaSilla { get => FilaInicioCroupier + 9; }
        private int OffsetFilaApueta { get => 3; }
        private int[] OffsetFilaBajoDatosApostador { get; set; }
        
        private static string[] Nombres = new string[] { "Juanjo", "Xusa", "Carmen", "Emy" };
        private static int iNombre = 0;

        private void MuestraCartasEnMazos(int cartasEnReparto, int cartasRetiradas)
        {
            int filaMazos = FilaInicioCroupier + 3;
            string textoMazoReparto = "MAZO REPARTO [";
            int x = Columnas / 4 - (textoMazoReparto.Length + 4) / 2;
            ConsoleE.Printf(x, filaMazos, textoMazoReparto);
            ConsoleE.PrintfConColor(x + textoMazoReparto.Length, filaMazos, $"{cartasEnReparto:D3}]", ConsoleColor.Yellow);
            ConsoleE.Printf(x + textoMazoReparto.Length + 3, filaMazos, "]");

            string textoMazoRetirada = "MAZO RETIRADA [";
            x = Columnas / 2 + (Columnas / 4 - (textoMazoRetirada.Length + 4) / 2);
            ConsoleE.Printf(x, filaMazos, textoMazoRetirada);
            ConsoleE.PrintfConColor(x + textoMazoRetirada.Length, filaMazos, $"{cartasRetiradas:D3}]", ConsoleColor.Yellow);
            ConsoleE.Printf(x + textoMazoRetirada.Length + 3, filaMazos, "]");
        }

        private Point PosicionSilla(int silla)
        {
            int separacionEntreJugadores = AnchoSillaJugador + SeparacionSillas;
            int offsetXInicial = separacionEntreJugadores - AnchoSillaJugador - 2;
            int x = offsetXInicial + separacionEntreJugadores * silla;
            return new Point(x, FilaSilla);
        }

        private void MuestraCarta(Carta c, int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = c._Color == Carta.Color.Negro ? ConsoleColor.Black : ConsoleColor.Red;
            ConsoleE.Printf(x, y, $"{c.SimboloValor,2} {c.SimboloPalo} ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void MuestraMano(Jugador j, int x, int y, out int yFinal)
        {
            if (j.Mano is ManoApostador ma)
                ConsoleE.Printf(x, y++, $"Apuesta: {ma.Apuesta}$");
            foreach (Carta c in j.Mano)
                MuestraCarta(c, x, y++);
            yFinal = y;
        }

        private void MustraJugador(Jugador j, int x, int y, out int yfinal)
        {
            ConsoleE.Printf(x, y++, $"{j}");
            if (j is Apostador a)
                ConsoleE.Printf(x, y++, $"Saldo: {a.Saldo:F0}$");
            else
                y++;
            if (j.ManoIniciada)
            {
                MuestraMano(j, x, y, out y);
                if (j.Mano.Puntos > 0)
                    ConsoleE.PrintfConColor(
                            x, y++,
                            $"{(j.ManoIniciada ? j.Mano.TextoPuntos : "0")}",
                            j.Mano.SePasa ? ConsoleColor.Red : ConsoleColor.Green);
                if (j.Mano.BlackJack)
                    ConsoleE.PrintfConColor(x, y++, "BLACKJACK!", ConsoleColor.Yellow);
                else if (j.Mano.SePasa)
                    ConsoleE.PrintfConColor(x, y++, "SE PASA!", ConsoleColor.Red);
            }
            yfinal = y;
        }

        public VistaTest()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetWindowSize(Columnas, Filas);
            Console.SetBufferSize(Columnas, Filas);
            Console.CursorVisible = false;
            OffsetFilaBajoDatosApostador = null;
        }

        public int PideApostadoresEnMesa(int minimo, int maximo)
        {
            return 4;
        }

        public void PideDatosApostador(int silla, out string nombre, out int saldo)
        {
            nombre = Nombres[iNombre++];
            saldo = 10000;
        }

        public bool SeReparteOtraMano()
        {
            Thread.Sleep(1500);
            return true;
        }

        public void MuestraMesa(MesaBlackJack mesa)
        {
            Console.Clear();
            AnchoSillaJugador = Columnas / mesa.MaximoJugadores - SeparacionSillas;
            OffsetFilaBajoDatosApostador = new int[mesa.MaximoJugadores];
            MuestraCartasEnMazos(mesa.Croupier.CartasEnReparto, mesa.Croupier.CartasRetiradas);
            MustraJugador(mesa.Croupier, Columnas / 2 - mesa.Croupier.ToString().Length / 2, FilaInicioCroupier, out int yFinal);

            for (int i = 0; i < mesa.MaximoJugadores; i++)
            {
                var p = PosicionSilla(i);
                ConsoleE.PrintfConColor(p.X, p.Y, $"Silla {i + 1}", ConsoleColor.Yellow);
                if (i < mesa.NumeroApostadores)
                {
                    p = PosicionSilla(mesa[i].Silla);
                    MustraJugador(mesa[i], p.X, p.Y + 1, out yFinal);
                    OffsetFilaBajoDatosApostador[mesa[i].Silla] = Math.Abs(yFinal - FilaSilla) + 1;
                }
            }
        }

        public Apostador.Accion PideAccionMano(Apostador a)
        {
            Apostador.Accion accion;

            if (a.Mano.Puntos >= 10 && a.Mano.Puntos <= 12 && a.PuedeDoblarse)
                accion = Apostador.Accion.Doblarse;
            else if (a.Mano.Puntos < 15 && a.PuedePedirCarta)
                accion = Apostador.Accion.Carta;
            else
                accion = Apostador.Accion.Plantarse;

            return accion;
        }

        public int PideApuesta(Apostador a)
        {
            return 2000 > a.Saldo ? a.Saldo : 2000;
        }

        public void MuestraResultadoApostador(ManoBlackJack manoCroupier, ManoBlackJack manoApostador, int sillaApostador)
        {
            var p = PosicionSilla(sillaApostador);
            int y = p.Y + OffsetFilaBajoDatosApostador[sillaApostador];

            string mensaje;
            ConsoleColor color;
            if (manoCroupier.CompareTo(manoApostador) == 0)
            {
                mensaje = "EMPATE!";
                color = ConsoleColor.Yellow;
            }
            else if (manoCroupier.CompareTo(manoApostador) > 0)
            {
                mensaje = "PIERDES!";
                color = ConsoleColor.Red;
            }
            else
            {
                mensaje = "GANAS!";
                color = ConsoleColor.Green;

            }

            ConsoleE.PrintfConColor(p.X, y, mensaje, color);
        }
        public void MuestraMensaje(string texto)
        {
            ConsoleE.PrintfConColor(0, FilaMensajes, texto, ConsoleColor.Blue);
        }

        public void MuestraAccionCroupier(string accion, int duracion_sg)
        {
            int x = Columnas / 2 - accion.Length / 2;
            int y = FilaInicioCroupier + 1;
            ConsoleE.PrintfConColor(x, y, accion, ConsoleColor.Blue);
            Thread.Sleep(duracion_sg * 1000);
            ConsoleE.Borra(x, y, accion.Length);
        }
    }
}
