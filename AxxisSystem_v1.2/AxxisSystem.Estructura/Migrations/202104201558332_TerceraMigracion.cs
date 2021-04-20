namespace AxxisSystem.Estructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerceraMigracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacto", "IMC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacto", "IMC", c => c.Single(nullable: false));
        }
    }
}
