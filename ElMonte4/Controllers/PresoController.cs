using ElMonte4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElMonte4.Controllers
{
    public class PresoController : ApiController
    {
        private ElMonte4DBContext context;

        public PresoController()
        {
            this.context = new ElMonte4DBContext();
        }


        //agrega preso
        //api/preso
        public IHttpActionResult post(Preso preso)
        {

            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }

        //modifica presos
        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

        //elimina preso
        public IHttpActionResult delete(int id)
        {
            //buscamos el preso a eliminar
            Preso preso = context.Presos.Find(id);

            if (preso == null) return NotFound();//404

            context.Presos.Remove(preso);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        // listar presos
        public IEnumerable<Object> get()
        {
            return context.Presos.Include("Condena").Select(c => new
            {

                ID = c.ID,
                Rut = c.Rut,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                FechaNacimiento = c.FechaNacimiento,
                Domicilio = c.Domicilio,
                Sexo = c.sexo,
                Condena = c.Condena.Select(g => new {
                    ID = g.ID,
                    FechaInicioCondena = g.FechaInicioCondena,
                    FechaCondena = g.FechaCondena,
                    CondenaDelito =  g.CondenaDelito.Select(cd => new {
                        Delito = new
                        {
                            ID = cd.Delito.ID,
                            Nombre = cd.Delito.Nombre,
                            CondenaMinima = cd.Delito.CondenaMinima,
                            CondenaMaxima = cd.Delito.CondenaMaxima
                        }
                    })

                })
                      
            });
        }
        //buscar presos
        public IHttpActionResult get(int id)
        {
            Preso preso = context.Presos.Find(id);

            if (preso == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(preso);//retornamos codigo 200 junto con el preso buscado
        }






    }
}