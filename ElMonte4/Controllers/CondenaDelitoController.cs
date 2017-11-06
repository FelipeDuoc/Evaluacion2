using ElMonte4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ElMonte4.Controllers
{
    public class CondenaDelitoController : ApiController
    {

        private ElMonte4DBContext context;

        public CondenaDelitoController()
        {
            this.context = new ElMonte4DBContext();
        }

        //agrega condenadelito
        //api/condenadelito
        public IHttpActionResult post(CondenaDelito condenaDelito)
        {

            context.CondenaDelitos.Add(condenaDelito);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }

        //modifica condenadelito
        public IHttpActionResult put(CondenaDelito condenaDelito)
        {
            context.Entry(condenaDelito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

        //elimina condenadelito
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            CondenaDelito condenaDelito = context.CondenaDelitos.Find(id);

            if (condenaDelito == null) return NotFound();//404

            context.CondenaDelitos.Remove(condenaDelito);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        // listar condenadelitos
        public IEnumerable<Object> get()
        {
            return context.CondenaDelitos.Select(cd => new
            {

                ID = cd.ID,
                CondenaID = cd.condenaId,
                DelitoID = cd.delitoId,
                Condena  = cd.condena

            });
        }
        //buscar condenadelito
        public IHttpActionResult get(int id)
        {
            CondenaDelito condenaDelito = context.CondenaDelitos.Find(id);

            if (condenaDelito == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(condenaDelito);
        }
    }
}