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

        List<Preso> preso = new List<Preso>()
        {
            new Preso() {   Nombre = "Rodrigo",
                            Apellido ="Berrios",
                            Rut ="1111111",
                            FechaNacimiento =Convert.ToDateTime("02/02/1994"),
                            Domicilio = "pasaje 1 #456",
                            sexo = 0,
                            ID = 1,
                            Condena = new List<Condena>() {
                                 //new Condena() { }
                            }
            }
        };

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
                        ID = cd.ID,
                        Condena = cd.condena,
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
    }
}