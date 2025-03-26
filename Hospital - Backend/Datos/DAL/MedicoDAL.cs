using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Modelo.Modelos;

namespace Datos.DAL
{
    public class MedicoDAL //entidad
    {
        public static ListadoPaginadoVMR<MedicoVMR> LeerTodo(int cantidad, int pagina, string texto)
        //estática para permitir acceder con el nombre de la clase sin crear un objeto
        //cantidad de elementos por página, texto de busqueda
        //devolver una clase View Model
        {
            ListadoPaginadoVMR<MedicoVMR> resultado = new ListadoPaginadoVMR<MedicoVMR>();

            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var query = db.Médico.Where(x => !x.borrado).Select(x => new MedicoVMR
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre + " " + x.apellidoPaterno + (x.apellidoMaterno != null ? (" " + x.apellidoMaterno) : ""),
                    esEspecialista = x.esEspecialista
                }); //expresión lambda, consulta parcial

                if (!string.IsNullOrEmpty(texto))
                {
                    query = query.Where(x => x.cedula.Contains(texto) || x.nombre.Contains(texto)); //aplica el filtro por texto de búsqueda
                }

                resultado.cantidadTotal = query.Count(); //devuelve la cantidad de médicos que no esten borrados y los que se encontraron por el texto de búsqueda

                resultado.elemento = query.OrderBy(x => x.id)
                                          .Skip(pagina * cantidad) //visualización de elementos
                                          .Take(cantidad) //límite a mostrar
                                          .ToList(); //convertir la consulta a una lista
            }
            return resultado;
        }

        public static MedicoVMR LeerUno(long id) //tipo bigint
        {
            MedicoVMR item = null;
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                item = db.Médico.Where(x => !x.borrado && x.id == id).Select(x => new MedicoVMR
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre,
                    apellidoPaterno = x.apellidoPaterno,
                    apellidoMaterno = x.apellidoMaterno,
                    habilitado = x.habilitado,
                    esEspecialista = x.esEspecialista
                }).FirstOrDefault();
            }

            return item;
        }

        public static long Crear(Médico item) //medico es la entidad
            //devuelve la PK del elemento creado
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                
                item.borrado = false;
                db.Médico.Add(item);
                db.SaveChanges();
            }
            return item.id;
        }

        public static void Actualizar(MedicoVMR item)//contiene los datos a actualizar
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var itemUpdate = db.Médico.Find(item.id);

                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidoPaterno = item.apellidoPaterno;
                itemUpdate.apellidoMaterno = item.apellidoMaterno;
                itemUpdate.habilitado = item.habilitado;
                itemUpdate.esEspecialista = item.esEspecialista;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(List<long> ids)
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var items = db.Médico.Where(x => ids.Contains(x.id));
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
