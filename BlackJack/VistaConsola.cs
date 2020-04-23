using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace BlackJack
{
    /*public class VistaConsola : IVista
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

        public VistaConsola()
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
            string patron = $"^[{minimo}-{maximo}]$";
            string respuesta = ConsoleE.ReadWithLabel(
                                    0, FilaMensajes,
                                    $"¿Cuantos jugadores quieres sentar? (Mín {minimo} - Máx {maximo}): ",
                                    1, patron);
            return int.Parse(respuesta);
        }

        public void PideDatosApostador(int silla, out string nombre, out int saldo)
        {
            nombre = ConsoleE.ReadWithLabel(
                                    0, FilaMensajes,
                                    $"Nombre Apostador{ silla + 1}: ",
                                    AnchoSillaJugador - 5, @"^[A-Za-z0-9\s]+$");
            saldo = int.Parse(ConsoleE.ReadWithLabel(
                                    0, FilaMensajes,
                                    $"Saldo Inicial Apostador{ silla + 1}: ",
                                    5, "^[0-9]+$"));
        }

        public bool SeReparteOtraMano()
        {
            string respuesta = ConsoleE.ReadWithLabel(
                                    0, FilaMensajes,
                                    "¿Jugar optra mano? (S/N): ",
                                    1, "^[sSnN]$");
            return respuesta.ToUpper() == "S";
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
            List<string> opciones = new List<string>();
            int opcion = 1;
            string patron = "^[";
            if (a.PuedePedirCarta)
            {
                opciones.Add($"{opcion} {Apostador.Accion.Carta}");
                patron += opcion++;
            }
            if (a.PuedePedirCarta)
            {
                opciones.Add($"{opcion} {Apostador.Accion.Plantarse}");
                patron += opcion++;
            }
            if (a.PuedeDoblarse)
            {
                opciones.Add($"{opcion} {Apostador.Accion.Doblarse}");
                patron += opcion++;
            }
            patron += "]+$";

            var p = PosicionSilla(a.Silla);
            int y = p.Y + OffsetFilaBajoDatosApostador[a.Silla];
            foreach (var o in opciones)
                ConsoleE.Printf(p.X, y++, o);
            opcion = int.Parse(ConsoleE.ReadWithLabel(p.X, y++, $"Opción: ", 1, patron));

            return (Apostador.Accion)Enum.Parse(typeof(Apostador.Accion), opciones[opcion - 1].Substring(2)); ;
        }

        public int PideApuesta(Apostador a)
        {
            var p = PosicionSilla(a.Silla);
            int apuesta;
            do
            {
                apuesta = int.Parse(ConsoleE.ReadWithLabel(
                                    p.X, p.Y + OffsetFilaApueta,
                                    "Apuesta: ", 3, "^[0-9]+$"));
                if (apuesta > a.Saldo)
                {
                    string mensaje = "Saldo insuficiente!";
                    ConsoleE.PrintfConColor(p.X, p.Y + OffsetFilaApueta, mensaje, ConsoleColor.Red);
                    Thread.Sleep(1000);
                    ConsoleE.Borra(p.X, p.Y + OffsetFilaApueta, mensaje.Length);
                }
            } while (apuesta > a.Saldo);
            return apuesta;
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
    }*/
}
