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

        private void ReparteCartasIniciales()
        {

        }

        private void InicializaMano()
        {

        }

        private void LevantaJugadoresSinSaldo()
        {

        }

        private bool FinalizaMano()
        {

        }

        private void SientaApostadores()
        {

        }

        private void TurnosApostadores()
        {

        }

        private void TurnoCroupier()
        {

        }

        public void EmpiezaJuego()
        {

        }
    }
}
