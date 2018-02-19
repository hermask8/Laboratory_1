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
        private T element;
        private Nodo<T> next;
        private Nodo<T> prev;
        public Nodo(T element, Nodo<T> prevNode, Nodo<T> nextNode)
        {
            this.element = element;
            this.prev = prevNode;
            this.next = nextNode;
        }
        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        public Nodo<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Nodo<T> Previous
        {
            get { return this.prev; }
            set { this.prev = value; }
        }

    }
    public class ListaGenerica<T>: IEnumerable<T>
    {
        private Nodo<T> Raiz = null;
        private Nodo<T> Ultimo = null;
        private int tamaño = 0;
        public ListaGenerica()
        {
            Raiz = new Nodo<T>(default(T), null, null);
            Ultimo = new Nodo<T>(default(T), Raiz, null);
            Raiz.Next = Ultimo;
        }
        public int Tamaño()
        {
            return tamaño;
        }

        public bool estaVacio()
        {
            return tamaño == 0;
        }
        public T Primero()
        {
            if (estaVacio())
                return default(T);
            T ele = Raiz.Previous.Element;
            return ele;
        }

        public T ultimoLista()
        {
            if (estaVacio())
                return default(T);
            return Ultimo.Previous.Element;
        }
        public void AgregarPrimero(T e)
        {
            AgregarEntre(e, Raiz, Raiz.Next);
        }

        public void AgregarUltmo(T e)
        {
            AgregarEntre(e, Ultimo.Previous, Ultimo);
        }

        public T RemoverPrimero()
        {
            if (estaVacio())
                return default(T);
            return Remover(Raiz.Next);
        }
        public T removeLast()
        {
            if (estaVacio())
                return default(T);
            return Remover(Ultimo.Previous);
        }
        private void AgregarEntre(T e, Nodo<T> predecessor, Nodo<T> successor)
        {
            Nodo<T> newest = new Nodo<T>(e, predecessor, successor);
            predecessor.Next = newest;
            successor.Previous = newest;
            tamaño++;
        }
        private T Remover(Nodo<T> node)
        {
            Nodo<T> predecessor = node.Previous;
            Nodo<T> successor = node.Next;
            predecessor.Next = successor;
            successor.Previous = predecessor;
            tamaño--;
            return node.Element;
        }

        public Nodo<T> retorno()
        {
            return Raiz;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nodo = Raiz;
            while (nodo!= null)
            {
                yield return nodo.Element;
                nodo = nodo.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
