namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class infoempresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresas", "infoEmpresa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empresas", "infoEmpresa");
        }
    }
}
