using ElMonte4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ElMonte4.Controllers
{
    public class CondenaController : ApiController
    {

        private ElMonte4DBContext context;

        public CondenaController()
        {
            this.context = new ElMonte4DBContext();
        }

        //agrega condena
        //api/condena
        public IHttpActionResult post(Condena condena)
        {

            context.Condenas.Add(condena);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }

        //modifica condena
        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

        //elimina condena
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            Condena condena = context.Condenas.Find(id);

            if (condena == null) return NotFound();//404

            context.Condenas.Remove(condena);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        // listar Condenas
        public IEnumerable<Object> get()
        {
            return context.Condenas.Include("Preso").Select(c => new
            {
                ID = c.ID,
                FechaInicioCondena = c.FechaInicioCondena,
                FechaRegistroCondena = c.FechaCondena,
                Preso = new
                {
                    ID = c.Preso.ID,
                    Rut = c.Preso.Rut,
                    Nombre = c.Preso.Nombre,
                    Apellido = c.Preso.Apellido,
                    FechaNacimiento = c.Preso.FechaNacimiento,
                    Domicilio = c.Preso.Domicilio,
                    Sexo = c.Preso.sexo
                },
                CondenaDelito = c.CondenaDelito.Select(cd => new {
                    ID = cd.Delito.ID,
                    Nombre = cd.Delito.Nombre,
                    CondenaMinima = cd.Delito.CondenaMinima,
                    CondenaMaxima = cd.Delito.CondenaMaxima        
                })

            });
        }
        //buscar condenas
        public IHttpActionResult get(int id)
        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(condena);//retornamos codigo 200 junto con la condena buscada
        }




    }
}