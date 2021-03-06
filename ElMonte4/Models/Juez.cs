﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElMonte4.Models
{
    [Table("Juez")]
    public class Juez
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public int Sexo { get; set; }
        public string Domicilio { get; set; }
        public List<Condena> Condena { get; set; }

    }
}