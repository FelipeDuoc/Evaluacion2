namespace ElMonte4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeramigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        condenaId = c.Int(nullable: false),
                        delitoId = c.Int(nullable: false),
                        condena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Condenas", t => t.condenaId, cascadeDelete: true)
                .ForeignKey("dbo.Delitoes", t => t.delitoId, cascadeDelete: true)
                .Index(t => t.condenaId)
                .Index(t => t.delitoId);
            
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Int(nullable: false),
                        JuezId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Juezs", t => t.JuezId, cascadeDelete: true)
                .ForeignKey("dbo.Presoes", t => t.PresoId, cascadeDelete: true)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "dbo.Juezs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Sexo = c.Int(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Presoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                        sexo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Delitoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CondenaMinima = c.Int(nullable: false),
                        CondenaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CondenaDelitoes", "delitoId", "dbo.Delitoes");
            DropForeignKey("dbo.Condenas", "PresoId", "dbo.Presoes");
            DropForeignKey("dbo.Condenas", "JuezId", "dbo.Juezs");
            DropForeignKey("dbo.CondenaDelitoes", "condenaId", "dbo.Condenas");
            DropIndex("dbo.Condenas", new[] { "JuezId" });
            DropIndex("dbo.Condenas", new[] { "PresoId" });
            DropIndex("dbo.CondenaDelitoes", new[] { "delitoId" });
            DropIndex("dbo.CondenaDelitoes", new[] { "condenaId" });
            DropTable("dbo.Delitoes");
            DropTable("dbo.Presoes");
            DropTable("dbo.Juezs");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitoes");
        }
    }
}
