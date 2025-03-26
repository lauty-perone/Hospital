using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Datos.DAL;
using Modelo.Modelos;

namespace Logica.BBL
{
    public class IngresoBBL
    {
        public static ListadoPaginadoVMR<IngresoVMR> LeerTodo(int cantidad, int pagina, string texto)
        {
            return IngresoDAL.LeerTodo(cantidad, pagina, texto);
        }
        public static IngresoVMR LeerUno(long id)
        {
            return IngresoDAL.LeerUno(id);
        }
        public static long Crear(Ingreso item)
        {
            return IngresoDAL.Crear(item);
        }
        public static void Actualizar(IngresoVMR item)
        {
            IngresoDAL.Actualizar(item);
        }
        public static void Eliminar(List<long> ids)
        {
            IngresoDAL.Eliminar(ids);
        }
    }
}
