namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class infohorarioinfocliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "infoHorario", c => c.Int(nullable: false));
            AddColumn("dbo.EmpresaCliente", "infoCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmpresaCliente", "infoCliente");
            DropColumn("dbo.Agenda", "infoHorario");
        }
    }
}
