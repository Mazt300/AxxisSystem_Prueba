namespace AxxisSystem.Estructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacto", "IMC", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacto", "IMC");
        }
    }
}
