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
    public class EgresoBBL
    {
        public static ListadoPaginadoVMR<EgresoVMR> LeerTodo(int cantidad, int pagina, string texto)
        {
            return EgresoDAL.LeerTodo(cantidad, pagina, texto);
        }
        public static EgresoVMR LeerUno(long id)
        {
            return EgresoDAL.LeerUno(id);
        }
        public static long Crear(Egreso item)
        {
            return EgresoDAL.Crear(item);
        }
        public static void Actualizar(EgresoVMR item)
        {
            EgresoDAL.Actualizar(item);
        }
        public static void Eliminar(List<long> ids)
        {
            EgresoDAL.Eliminar(ids);
        }
    }
}
