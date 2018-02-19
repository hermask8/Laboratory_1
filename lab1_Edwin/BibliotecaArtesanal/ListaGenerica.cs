using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaArtesanal
{
    public class Nodo<T>
    {
        public T Objeto;
        public Nodo<T> Siguiente;
        public Nodo<T> Anterior;



    }
    public class ListaGenerica<T> : InterfazGenerica<T>,IEnumerable<T> where T: IComparable
    {
        public Nodo<T> Raiz;
        public Nodo<T> Ultimo;
        public Nodo<T> anterior;
        public ListaGenerica()
        {
            Raiz = null;
            Ultimo = null;
        }
        public void Agregar(T Ingreso)
        {
            Nodo<T> nuevo = null;
            nuevo.Objeto = Ingreso;
            nuevo.Siguiente = null;
            nuevo.Anterior = null;

            if (Raiz==null)
            {
                Raiz = nuevo;
                Raiz.Siguiente = null;
                Ultimo = Raiz;
            }
            else
            {
                Ultimo.Siguiente = nuevo;
                nuevo.Siguiente = null;
                anterior = Ultimo;
                Ultimo = nuevo;
                Ultimo.Anterior = anterior;
            }
        }

        public void Eliminar(T Ingreso)
        {
            
            Nodo<T> recorrer = Raiz;
            while (recorrer != null)
            {
                if (recorrer.Objeto.CompareTo(Ingreso)==0)
                {
                    if (recorrer==Raiz)
                    {
                        Raiz = Raiz.Siguiente;
                        Raiz.Anterior = null;
                    }
                    else if (recorrer==Ultimo)
                    {
                        Ultimo = Ultimo.Anterior;
                        Ultimo.Siguiente = null;
                    }
                    else
                    {
                        recorrer.Anterior.Siguiente = recorrer.Siguiente;
                        recorrer.Siguiente.Anterior = recorrer.Anterior;
                    }
                }
                else
                {
                    recorrer = recorrer.Siguiente;
                }
            }
            
        }



        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Nodo<T> retornar()
        {
            return Raiz;
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
