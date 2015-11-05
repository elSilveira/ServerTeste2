namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class especializacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmpresaCliente", "especializacaoCliente", c => c.String());
            AddColumn("dbo.EmpresaCliente", "especializacao2Cliente", c => c.String());
            AddColumn("dbo.EmpresaCliente", "especializacao3Cliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmpresaCliente", "especializacao3Cliente");
            DropColumn("dbo.EmpresaCliente", "especializacao2Cliente");
            DropColumn("dbo.EmpresaCliente", "especializacaoCliente");
        }
    }
}
