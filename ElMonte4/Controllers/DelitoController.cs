﻿using ElMonte4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ElMonte4.Controllers
{
    [AuthenticationFilter]
    public class DelitoController : ApiController
    {
        private ElMonte4DBContext context;

        public DelitoController()
        {
            this.context = new ElMonte4DBContext();
        }

        //agrega delito
        //api/delito
        public IHttpActionResult post(Delito delito)
        {

            context.Delitos.Add(delito);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }

        //modifica delitos
        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

        //elimina delito
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            Delito delito = context.Delitos.Find(id);

            if (delito == null) return NotFound();//404

            context.Delitos.Remove(delito);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        // listar delitos
        public IEnumerable<Object> get()
        {
            return context.Delitos.Select(d => new
            {

                ID = d.ID,
                Nombre = d.Nombre,
                CondenaMinima = d.CondenaMinima,
                CondenaMaxima = d.CondenaMaxima

            });
        }
        //buscar delitos
        public IHttpActionResult get(int id)
        {
            Delito delito = context.Delitos.Find(id);

            if (delito == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(delito);//retornamos codigo 200 junto con el delito buscado
        }


    }
}