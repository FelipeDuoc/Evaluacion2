using ElMonte4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElMonte4.Controllers
{
    public class JuezController : ApiController
    {
        private ElMonte4DBContext context;

        public JuezController()
        {
            this.context = new ElMonte4DBContext();
        }

        //agrega juez
        //api/juez
        public IHttpActionResult post(Juez juez)
        {

            context.Juezs.Add(juez);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }

        //modifica juez
        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

        //elimina juez
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            Juez juez = context.Juezs.Find(id);

            if (juez == null) return NotFound();//404

            context.Juezs.Remove(juez);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        // listar jueces
        public IEnumerable<Object> get()
        {
            return context.Juezs.Select(j => new
            {
                ID = j.ID,
                Nombre = j.Nombre,
                Rut = j.Rut,
                Sexo = j.Sexo,
                Domicilio = j.Domicilio
                
            });
        }
        //buscar jueces
        public IHttpActionResult get(int id)
        {
            Juez juez = context.Juezs.Find(id);

            if (juez == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(juez);//retornamos codigo 200 junto con el juez buscado
        }

    }
}