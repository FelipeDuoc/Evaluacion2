namespace ElMonte4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ElMonte4.Models.ElMonte4DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ElMonte4.Models.ElMonte4DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Presos.AddOrUpdate(
            //    p => p.Nombre,
            //        new Models.Preso { ID = 1, Rut = "123456", Nombre = "nombre preso", Apellido = "apellido preso", FechaNacimiento = Convert.ToDateTime("05-11-1990"), Domicilio = "domicilio prueba", sexo = 1  }
            //    );

            //context.Condenas.AddOrUpdate(
            //    c => c.ID,
            //        new Models.Condena { ID=1, FechaInicioCondena = Convert.ToDateTime("05-11-2016"), FechaCondena = Convert.ToDateTime("05-11-2016"),PresoId = 1, JuezId = 1}
            //    );

            //context.CondenaDelitos.AddOrUpdate(
            //   cd => cd.ID,
            //       new Models.CondenaDelito {condenaId = 1 , delitoId = 1, condena = 1}
            //   );

            context.Delitos.AddOrUpdate(
               d => d.Nombre,
                   new Models.Delito { ID = 1, Nombre = "Homicidio" , CondenaMinima = 5, CondenaMaxima = 20},
                   new Models.Delito { ID = 2, Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                   new Models.Delito { ID = 3, Nombre = "Robo con intimidación", CondenaMinima = 1, CondenaMaxima = 12 },
                   new Models.Delito { ID = 4, Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                   new Models.Delito { ID = 5, Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }

               );

            //context.Juezs.AddOrUpdate(
            //    j => j.Nombre,
            //        new Models.Juez { ID=1, Nombre = "nombre juez", Rut = "123456", Sexo = 1, Domicilio = "domicilio juez" }
            //    );


            context.Usuarios.AddOrUpdate(u => u.UserName,
                new Models.Usuario() { UserName = "admin", Password = "admin" },
                new Models.Usuario() { UserName = "rodrigo", Password = "1234"}
                );

        }
    }
}
