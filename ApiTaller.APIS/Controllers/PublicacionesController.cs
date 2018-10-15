using ApiTaller.APIS.Models;
using ClasesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTaller.APIS.Controllers
{
    public class PublicacionesController : ApiController
    {
        //Get para consultar todos los registros
        [HttpGet]
        public IEnumerable<Publicacion> Get()
        {
            using (var context = new PublicacionContext())
            {
                return context.Publicaciones.ToList();
            }
        }

        //Get con parametro, para consultar uno de los registros
        [HttpGet]
        public Publicacion Get(int id)
        {
            using (var context = new PublicacionContext())
            {
                return context.Publicaciones.FirstOrDefault(x => x.Id == id);
            }
        }

        //Post, insertar un registro
        [HttpPost]
        public IHttpActionResult Post(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new PublicacionContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges();
                return Ok(publicacion);
            }
        }

        //Put, actualizar un registro
        /*FirstOrDefault, es un método que retorna el primer elemento o 
          en caso no existan devolverá el valor predeterminado*/
        [HttpPut]
        public Publicacion Put(Publicacion publicacion)
        {
            using (var context = new PublicacionContext())
            {
                var publicacionActualizar = context.Publicaciones.FirstOrDefault(x => x.Id == publicacion.Id);
                publicacionActualizar.Usuario = publicacion.Usuario;
                publicacionActualizar.Descripcion = publicacion.Descripcion;
                publicacionActualizar.FechaPublicacion = publicacion.FechaPublicacion;
                publicacionActualizar.MeGusta = publicacion.MeGusta;
                publicacionActualizar.MeDisguta = publicacion.MeDisguta;
                publicacionActualizar.VecesCompartido = publicacion.VecesCompartido;
                publicacionActualizar.EsPrivada = publicacion.EsPrivada;
                context.SaveChanges();
                return publicacion;
            }
        }


        //Delete, permite eliminar un registro, ingresando como parametro el Id
        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new PublicacionContext())
            {
                var publicacionDelete = context.Publicaciones.FirstOrDefault(x => x.Id == id);
                context.Publicaciones.Remove(publicacionDelete);
                context.SaveChanges();
                return true;
            }
        }
    }
}
