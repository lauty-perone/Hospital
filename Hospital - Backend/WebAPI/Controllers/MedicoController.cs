using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Comun.ViewModels;
using Logica.BBL;
using Modelo.Modelos;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*" , methods: "*")]
    public class MedicoController : ApiController
    {
        [HttpGet] //La vía en la que se debe utilizar
        public IHttpActionResult LeerTodo(int cantidad = 10, int pagina = 0,string textoBusqueda = null)
        {
            var respuesta = new RespuestaVMR<ListadoPaginadoVMR<MedicoVMR>>();
            try
            {
                respuesta.datos = MedicoBBL.LeerTodo(cantidad, pagina, textoBusqueda);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpGet]
        public IHttpActionResult LeerUno(long id)
        {
            var respuesta = new RespuestaVMR<MedicoVMR>();
            try
            {
                respuesta.datos = MedicoBBL.LeerUno(id);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            if (respuesta.datos == null && respuesta.mensajes.Count() == 0)
            {
                respuesta.codigo = HttpStatusCode.NotFound;
                respuesta.mensajes.Add("Elemento no encontrado");
            }
            return Content(respuesta.codigo, respuesta);
        }

        [HttpPost]
        public IHttpActionResult Crear(Médico item)
        {
            var respuesta = new RespuestaVMR<long?>(); //la interrogación permite valores nulos.
            try
            {
                respuesta.datos = MedicoBBL.Crear(item);
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = null;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(long id , MedicoVMR item)
        {
            var respuesta = new RespuestaVMR<bool>(); //devuelve un booleano
            try
            {
                item.id = id; //para encontrar el elemento a actualizar
                MedicoBBL.Actualizar(item);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(List<long> ids)
        {
            var respuesta = new RespuestaVMR<bool>();
            try
            {
                MedicoBBL.Eliminar(ids);
                respuesta.datos = true;
            }
            catch (Exception e)
            {
                respuesta.codigo = HttpStatusCode.InternalServerError;
                respuesta.datos = false;
                respuesta.mensajes.Add(e.Message);
                respuesta.mensajes.Add(e.ToString());
            }

            return Content(respuesta.codigo, respuesta);
        }
    }
}
