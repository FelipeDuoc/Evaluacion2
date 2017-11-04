using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElMonte4.Models
{
    [Table("CondenaDelito")]
    public class CondenaDelito
    {
        public int ID { get; set; }
        public Condena Condena { get; set; }
        public int condenaId { get; set; }
        public Delito Delito { get; set; }
        public int delitoId { get; set; }
        public int condena { get; set; }   
    }
}