using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comun.ViewModels;
using Modelo.Modelos;

namespace Datos.DAL
{
    public class PacienteDAL //entidad
    {
        public static ListadoPaginadoVMR<PacienteVMR> LeerTodo(int cantidad, int pagina, string texto)
        //estática para permitir acceder con el nombre de la clase sin crear un objeto
        //cantidad de elementos por página, texto de busqueda
        //devolver una clase View Model
        {
            ListadoPaginadoVMR<PacienteVMR> resultado = new ListadoPaginadoVMR<PacienteVMR>();

            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var query = db.Paciente.Where(x => !x.borrado).Select(x => new PacienteVMR
                {
                    id = x.id,
                    cedula = x.cedula,
                    nombre = x.nombre + " " + x.apellidoPaterno + (x.apellidoMaterno != null ? (" " + x.apellidoMaterno) : ""),
                    direccion = x.direccion,
                    celular = x.celular,
                    correoElectronico = x.correoElectronico

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

        public static PacienteVMR LeerUno(long id) //tipo bigint
        {
            PacienteVMR item = null;
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                item = db.Paciente.Where(x => !x.borrado && x.id == id).Select(x => new PacienteVMR
                {
                    id = x.id,
                    cedula = x.cedula,
                    apellidoPaterno = x.apellidoPaterno,
                    apellidoMaterno = x.apellidoMaterno,
                    direccion = x.direccion,
                    celular = x.celular,
                    correoElectronico = x.correoElectronico
                }).FirstOrDefault();
            }

            return item;
        }

        public static long Crear(Paciente item)
        {
            long id = 0;
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                item.borrado = false;
                db.Paciente.Add(item);
                db.SaveChanges();
            }
            return id;
        }

        public static void Actualizar(PacienteVMR item)//contiene los datos a actualizar
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var itemUpdate = db.Paciente.Find(item.id);

                itemUpdate.cedula = item.cedula;
                itemUpdate.nombre = item.nombre;
                itemUpdate.apellidoPaterno = item.apellidoPaterno;
                itemUpdate.apellidoMaterno = item.apellidoMaterno;
                itemUpdate.direccion = item.direccion;
                itemUpdate.celular = item.celular;
                itemUpdate.correoElectronico = item.correoElectronico;
                db.Entry(itemUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void Eliminar(List<long> ids)
        {
            using (var db = DbConexion.Create()) //claúsula para la conexión con la DB
            {
                var items = db.Paciente.Where(x => ids.Contains(x.id));
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
