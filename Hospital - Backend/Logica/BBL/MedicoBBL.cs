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
    public class MedicoBBL
    {
        public static ListadoPaginadoVMR<MedicoVMR> LeerTodo(int cantidad, int pagina, string texto)
        {
            return MedicoDAL.LeerTodo(cantidad, pagina, texto);
        }
        public static MedicoVMR LeerUno(long id)
        {
            return MedicoDAL.LeerUno(id);
        }
        public static long Crear(Médico item)
        {
            return MedicoDAL.Crear(item);
        }
        public static void Actualizar(MedicoVMR item)
        {
            MedicoDAL.Actualizar(item);
        }
        public static void Eliminar(List<long> ids)
        {
            MedicoDAL.Eliminar(ids);
        }
    }
}
