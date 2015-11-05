namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upempc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmpresaCliente", "idServico", "dbo.Servicos");
            DropIndex("dbo.EmpresaCliente", new[] { "idServico" });
            DropColumn("dbo.EmpresaCliente", "idServico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmpresaCliente", "idServico", c => c.Int(nullable: false));
            CreateIndex("dbo.EmpresaCliente", "idServico");
            AddForeignKey("dbo.EmpresaCliente", "idServico", "dbo.Servicos", "idServico", cascadeDelete: true);
        }
    }
}
