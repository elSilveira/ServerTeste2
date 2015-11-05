namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servtoempx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmpresaCliente", "idServico", c => c.Int(nullable: false));
            CreateIndex("dbo.EmpresaCliente", "idServico");
            AddForeignKey("dbo.EmpresaCliente", "idServico", "dbo.Servicos", "idServico", cascadeDelete: true);
            DropColumn("dbo.EmpresaCliente", "infoCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmpresaCliente", "infoCliente", c => c.String());
            DropForeignKey("dbo.EmpresaCliente", "idServico", "dbo.Servicos");
            DropIndex("dbo.EmpresaCliente", new[] { "idServico" });
            DropColumn("dbo.EmpresaCliente", "idServico");
        }
    }
}
