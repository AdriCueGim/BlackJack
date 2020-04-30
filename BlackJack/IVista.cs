using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public interface IVista
    {
        void MuestraMesa(MesaBlackJack mesa);
        void MuestraAccionCroupier(string accion, int duracion_sg);
        void MuestraMensaje(string texto);
        void MuestraResultadoApostador(ManoBlackJack manoCroupier,
                                       ManoBlackJack manoApostador,
                                       int sillaApostador);
        int PideApostadoresEnMesa(int maximo, int minimo);
        void PideDatosApostador(int iApostadorEnMesa, out string nombre, out int saldo);
        int PideApuesta(Apostador a);
        Apostador.Accion PideAccionMano(Apostador a);
        bool SeReparteOtraMano();
    }
}
