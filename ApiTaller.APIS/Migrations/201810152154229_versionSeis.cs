namespace ApiTaller.APIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionSeis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publicacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Descripcion = c.String(),
                        FechaPublicacion = c.DateTime(nullable: false),
                        MeGusta = c.Int(nullable: false),
                        MeDisguta = c.Int(nullable: false),
                        VecesCompartido = c.Int(nullable: false),
                        EsPrivada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publicacions");
        }
    }
}
