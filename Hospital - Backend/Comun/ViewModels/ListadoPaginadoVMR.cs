using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class ListadoPaginadoVMR<T> //Tipo genérico(pacientes, medicos, etc)
    {   
        public int cantidadTotal { get; set; }
        public IEnumerable<T> elemento { get; set; } //interface, se contemplan las listas

        public ListadoPaginadoVMR()
        {
            elemento = new List<T>();
            cantidadTotal = 0;
        }
    }


}
