using lab1_Edwin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLinked
{
    class listaEnlazada
    {
        LinkedList<Jugadores> enlazada = new LinkedList<Jugadores>();
        
        public void agregar(Jugadores agrega)
        {
            if (enlazada.First==null)
            {
                enlazada.AddFirst(agrega);
            }
            else
            {
                enlazada.AddAfter(enlazada.First, agrega);
            }
        }

        public void eliminar(Jugadores elim)
        {
            foreach (var item in enlazada)
            {
                if (item.Nombre==elim.Nombre)
                {
                    enlazada.Remove(item);
                }
            }
        }

        public LinkedList<Jugadores> retornarLista()
        {
            return enlazada;
        }
    }
}
