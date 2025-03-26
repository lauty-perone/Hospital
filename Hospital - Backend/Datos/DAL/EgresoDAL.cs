using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Modelo.Modelos;

namespace Datos.DAL
{
    public class EgresoDAL //entidad
    {
        public static ListadoPaginadoVMR<EgresoVMR> LeerTodo(int cantidad, int pagina, string texto)
        //estática para permitir acceder con el nombre de la clase sin crear un objeto
        //cantidad de elementos por página, texto de busqueda
        //devolver una clase View Model
        {
            ListadoPaginadoVMR<EgresoVMR> resultado = new ListadoPaginadoVMR<EgresoVMR>();

            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var query = db.Egreso.Where(x => !x.borrado).Select(x => new EgresoVMR
                {
                    id = x.id,
                    fecha = x.fecha,
                    tratamiento = x.tratamiento,
                    monto = x.monto,
                    medicoId = x.medicoId,
                    pacienteId = x.pacienteId
                }); //expresión lambda, consulta parcial

                if (!string.IsNullOrEmpty(texto))
                {
                    query = query.Where(x => x.tratamiento.Contains(texto)); //aplica el filtro por texto de búsqueda
                }

                resultado.cantidadTotal = query.Count(); //devuelve la cantidad de médicos que no esten borrados y los que se encontraron por el texto de búsqueda

                resultado.elemento = query.OrderBy(x => x.id)
                                          .Skip(pagina * cantidad) //visualización de elementos
                                          .Take(cantidad) //límite a mostrar
                                          .ToList(); //convertir la consulta a una lista
            }
            return resultado;
        }

        public static EgresoVMR LeerUno(long id) //tipo bigint
        {
            EgresoVMR item = null;
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                item = db.Egreso.Where(x => !x.borrado && x.id == id).Select(x => new EgresoVMR
                {
                    id = x.id,
                    fecha = x.fecha,
                    tratamiento = x.tratamiento,
                    monto = x.monto,
                    medicoId = x.medicoId,
                    pacienteId = x.pacienteId
                }).FirstOrDefault();
            }

            return item;
        }

        public static long Crear(Egreso item)
        //devuelve la PK del elemento creado
        {
            long id = 0;
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                item.borrado = false;
                db.Egreso.Add(item);
                db.SaveChanges();
            }
            return id;
        }

        public static void Actualizar(EgresoVMR item)//contiene los datos a actualizar
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var itemUpdate = db.Egreso.Find(item.id);

                itemUpdate.fecha = item.fecha;
                itemUpdate.tratamiento = item.tratamiento;
                itemUpdate.monto = item.monto;
                itemUpdate.medicoId = item.medicoId;
                itemUpdate.pacienteId = item.pacienteId;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(List<long> ids)
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var items = db.Egreso.Where(x => ids.Contains(x.id));
                foreach (var item in items)
                {   //borrado lógico
                    item.borrado = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

            }
        }
    }
}
