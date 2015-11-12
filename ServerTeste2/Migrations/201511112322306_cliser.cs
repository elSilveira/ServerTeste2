namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClienteServico", "idEmpresaServico", "dbo.EmpresaServico");
            DropIndex("dbo.ClienteServico", new[] { "idEmpresaServico" });
            DropColumn("dbo.ClienteServico", "idEmpresaServico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClienteServico", "idEmpresaServico", c => c.Int(nullable: false));
            CreateIndex("dbo.ClienteServico", "idEmpresaServico");
            AddForeignKey("dbo.ClienteServico", "idEmpresaServico", "dbo.EmpresaServico", "idEmpresaServico", cascadeDelete: true);
        }
    }
}
