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
    public class PacienteBBL
    {
        public static ListadoPaginadoVMR<PacienteVMR> LeerTodo(int cantidad, int pagina, string texto)
        {
            return PacienteDAL.LeerTodo(cantidad, pagina, texto);
        }
        public static PacienteVMR LeerUno(long id)
        {
            return PacienteDAL.LeerUno(id);
        }
        public static long Crear(Paciente item)
        {
            return PacienteDAL.Crear(item);
        }
        public static void Actualizar(PacienteVMR item)
        {
            PacienteDAL.Actualizar(item);
        }
        public static void Eliminar(List<long> ids)
        {
            PacienteDAL.Eliminar(ids);
        }
    }
}
