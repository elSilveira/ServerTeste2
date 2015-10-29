namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iconeeinfocategoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "iconeCategoria", c => c.String());
            AddColumn("dbo.Categorias", "infoCategoria", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categorias", "infoCategoria");
            DropColumn("dbo.Categorias", "iconeCategoria");
        }
    }
}
