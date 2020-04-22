using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercico1.Datos
{
    public class Funciones : Variables, InterFunciones
    {
        private List<Variables> listVariables;
        public List<Variables> ListVariables
        {
            get { return listVariables; }
            set { listVariables = value; }
        }
        //Inicilizador
        public Funciones()
        {
            ListVariables = new List<Variables>();
        }
        public void modificarEstado(string estado, int codigo)
        {
            ListVariables.Where(w => w.codigo == codigo).ToList().ForEach(i => i.estado = estado);
        }
        public List<Variables> getVariables()
        {
            return ListVariables;
        }
        public List<Variables> getVariablesNombre(string nombre)
        {
            List<Variables> v = (from lis in ListVariables where lis.nombre.Contains(nombre) select lis).ToList();
            return v;
        }
        public List<Variables> getVariablesEstado(string Estado)
        {
            List<Variables> v = (from lis in ListVariables where lis.estado == estado select lis).ToList();
            return v;
        }

        public void Agregar(Variables variables)
        {
            ListVariables.Add(new Variables()
            {
                codigo=variables.codigo,
                nombre=variables.nombre,
                direccion=variables.direccion,
                telefono=variables.telefono,
                genero=variables.genero,
                trabajo=variables.trabajo,
                estado=variables.estado
            });
        }
    }
}
