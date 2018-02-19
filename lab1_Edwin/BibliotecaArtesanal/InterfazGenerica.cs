using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaArtesanal
{
    public interface InterfazGenerica<T>
    {
        void Agregar(T Ingreso);
        void Eliminar(T Ingreso);


    }
}
