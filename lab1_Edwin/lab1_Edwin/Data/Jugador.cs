using lab1_Edwin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1_Edwin.Data
{
    public class Jugador
    {
        private static Jugador instance;
        public static Jugador Instance
        {
            get
            {
                if (instance == null) instance = new Jugador();
                return instance;
            }
        }

        public List<Jugadores> Jugadores;
        public List<Jugadores> JugadoresEliminar;
        internal string Nombre;

        public Jugador()
        {
            Jugadores = new List<Jugadores>();
            JugadoresEliminar = new List<Jugadores>();
        }
    }
}