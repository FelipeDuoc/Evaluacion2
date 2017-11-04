namespace ElMonte4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CondenaDelitoes", newName: "CondenaDelito");
            RenameTable(name: "dbo.Juezs", newName: "Juez");
            RenameTable(name: "dbo.Presoes", newName: "Preso");
            RenameTable(name: "dbo.Delitoes", newName: "Delito");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Delito", newName: "Delitoes");
            RenameTable(name: "dbo.Preso", newName: "Presoes");
            RenameTable(name: "dbo.Juez", newName: "Juezs");
            RenameTable(name: "dbo.CondenaDelito", newName: "CondenaDelitoes");
        }
    }
}
