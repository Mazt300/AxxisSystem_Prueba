namespace AxxisSystem.Estructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PruebaBD_AxxisSystem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        IdContacto = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Peso = c.Int(nullable: false),
                        Estatura = c.Int(nullable: false),
                        Telefono = c.String(),
                        DireccionCorreoElectronico = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdContacto);
            
            CreateTable(
                "dbo.Direccion_Contacto",
                c => new
                    {
                        IdDireccion_Contacto = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        IdDepartamento = c.Int(nullable: false),
                        IdContacto = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdDireccion_Contacto)
                .ForeignKey("dbo.Contacto", t => t.IdContacto, cascadeDelete: true)
                .ForeignKey("dbo.Departamento", t => t.IdDepartamento, cascadeDelete: true)
                .Index(t => t.IdDepartamento)
                .Index(t => t.IdContacto);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        IdDepartamento = c.Int(nullable: false, identity: true),
                        NombreDepartamento = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdDepartamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccion_Contacto", "IdDepartamento", "dbo.Departamento");
            DropForeignKey("dbo.Direccion_Contacto", "IdContacto", "dbo.Contacto");
            DropIndex("dbo.Direccion_Contacto", new[] { "IdContacto" });
            DropIndex("dbo.Direccion_Contacto", new[] { "IdDepartamento" });
            DropTable("dbo.Departamento");
            DropTable("dbo.Direccion_Contacto");
            DropTable("dbo.Contacto");
        }
    }
}
