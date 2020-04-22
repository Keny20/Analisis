using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercico1.Datos
{
    interface InterFunciones
    {
        List<Variables> getVariables();

        void Agregar(Variables variables);

        List<Variables> getVariablesEstado(string estado);

        List<Variables> getVariablesNombre(string nombre);

        void modificarEstado(string estado, int codigo);
    }
}
