using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElMonte4.Models
{
    [Table("Delito")]
    public class Delito
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int CondenaMinima { get; set; }
        public int CondenaMaxima { get; set; }
        public List<CondenaDelito> CondenaDelito { get; set; }
    }
}