namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTokenUsuario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "tokenUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "tokenUsuario", c => c.String());
        }
    }
}
