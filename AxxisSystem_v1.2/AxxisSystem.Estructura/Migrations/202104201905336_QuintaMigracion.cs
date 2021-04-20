namespace AxxisSystem.Estructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuintaMigracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacto", "Peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Contacto", "Estatura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacto", "Estatura", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacto", "Peso", c => c.Int(nullable: false));
        }
    }
}
