using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Controlador
    {
        private IVista Vista { get; }
        private MesaBlackJack Mesa { get; }

        public Controlador(MesaBlackJack mesa, IVista vista)
        {
            Mesa = mesa;
            Vista = vista;
        }

        private void ReparteUnaCartaApostadores()
        {
            for (int i = 0; i < Mesa.NumeroApostadores; i++)
            {
                Mesa.Croupier.ReparteCarta(Mesa[i]);
                Vista.MuestraMesa(Mesa);
                Vista.MuestraAccionCroupier("Repartiendo...", 1);
            }
        }

        private void InicializaManos()
        {
            for (int i = 0; i < Mesa.NumeroApostadores; i++)
                Mesa[i].IniciaMano(Vista.PideApuesta(Mesa[i]));
            Mesa.Croupier.IniciaMano();
        }

        private void ReparteCartasIniciales()
        {
            Vista.MuestraMesa(Mesa);
            ReparteUnaCartaApostadores();
            Mesa.Croupier.RecibeCarta(Mesa.Croupier.MazoReparto.ExtraePrimera());
            Vista.MuestraMesa(Mesa);
            ReparteUnaCartaApostadores();
        }

        private void InicializaMano()
        {
            Vista.MuestraMesa(Mesa);
            if (!Mesa.Croupier.MazosInicializados)
            {
                Mesa.Croupier.AñadeBajajasAlMazoReparto();
                Vista.MuestraAccionCroupier("Inicializando mazo de reparto...", 2);
                Mesa.Croupier.MezclaMazoReparto();
                Vista.MuestraAccionCroupier("Mezclando...", 1);
                Vista.MuestraMesa(Mesa);
            }
            else
            {
                if (Mesa.Croupier.CartasEnReparto <= Mesa.MinimoCartasParaNuevaMano)
                {
                    Mesa.Croupier.ReiniciaMazoRepartoConCartasRetiradas();
                    Mesa.Croupier.MezclaMazoReparto();
                }
                Vista.MuestraAccionCroupier("Recuperando mazo de reparto...", 2);
                Vista.MuestraAccionCroupier("Mezclando...", 1);
            }
            InicializaManos();
            Vista.MuestraMesa(Mesa);
        }

        private void LevantaJugadoresSinSaldo()
        {
            for (int i = 0; i < Mesa.NumeroApostadores; i++)
            {
                if (Mesa[i].Saldo <= 0)
                    Mesa.Levanta(Mesa[i]);
            }
        }

        private bool FinalizaMano()
        {
            bool finalizarJuego = false;
            ManoBlackJack manoCroupier, manoApostador;
            Vista.MuestraMesa(Mesa);
            for (int i = 0; i < Mesa.NumeroApostadores; i++)
            {
                manoCroupier = Mesa.Croupier.Mano;
                manoApostador = Mesa[i].Mano;
                if (manoCroupier.CompareTo(manoApostador) == 0)
                    Mesa[i].Empata();
                else if (manoCroupier.CompareTo(manoApostador) < 0)
                    Mesa[i].Gana();
                Vista.MuestraResultadoApostador(Mesa.Croupier.Mano,
                                                Mesa[i].Mano,
                                                i);
                Mesa.Croupier.RetiraMano(Mesa[i]);
            }
            Vista.MuestraAccionCroupier("Repartiendo fichas...", 1);
            Mesa.Croupier.RetiraMano(Mesa.Croupier);
            Vista.MuestraMesa(Mesa);
            LevantaJugadoresSinSaldo();
            Vista.MuestraAccionCroupier("Retirando jugadores sin saldo...", 1);
            Vista.MuestraMesa(Mesa);
            if (Mesa.NumeroApostadores != 0)
                finalizarJuego = !Vista.SeReparteOtraMano();
            else if (Mesa.NumeroApostadores == 0)
                finalizarJuego = true;
            return finalizarJuego;
        }

        private void SientaApostadores()
        {
            int numeroApostadores = Vista.PideApostadoresEnMesa(
                                               Mesa.MinimoJugadores, 
                                               Mesa.MaximoJugadores);
            string nombreApostador;
            int saldoApostador;
            for (int i = 0; i < numeroApostadores; i++)
            {
                Vista.PideDatosApostador(
                            i,
                            out nombreApostador,
                            out saldoApostador);
                Mesa.Sienta(new Apostador(
                                    nombreApostador, 
                                    saldoApostador));
            }
        }

        private void RealizaAccionApostador(Apostador a, Apostador.Accion accion)
        {
            switch (accion)
            {
                case Apostador.Accion.Plantarse:
                    a.Plantarse();
                    break;
                case Apostador.Accion.Doblarse:
                    a.Doblarse();
                    Mesa.Croupier.ReparteCarta(a);
                    break;
                case Apostador.Accion.Carta:
                    Mesa.Croupier.ReparteCarta(a);
                    break;
                default:
                    break;
            }
        }

        private void TurnosApostadores()
        {
            Vista.MuestraMesa(Mesa);
            Apostador apostador;
            for (int i = 0; i < Mesa.NumeroApostadores; i++)
            {
                apostador = Mesa[i];
                while (!apostador.Mano.Cerrada)
                    RealizaAccionApostador(apostador, Vista.PideAccionMano(apostador));
                Vista.MuestraMesa(Mesa);
            }
        }

        private void TurnoCroupier()
        {
            while(!Mesa.Croupier.Mano.Cerrada)
                Mesa.Croupier.RecibeCarta(Mesa.Croupier.MazoReparto.ExtraePrimera());
            Vista.MuestraMesa(Mesa);
        }

        public void EmpiezaJuego()
        {
            Vista.MuestraMesa(Mesa);
            SientaApostadores();
            do
            {
                Vista.MuestraMesa(Mesa);
                InicializaMano();
                ReparteCartasIniciales();
                TurnosApostadores();
                TurnoCroupier();
            } while (!FinalizaMano());
        }
    }
}
