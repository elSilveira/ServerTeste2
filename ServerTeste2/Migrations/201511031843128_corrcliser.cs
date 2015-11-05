namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrcliser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClienteServico", "EmpresaServico_idEmpresaServico", "dbo.EmpresaServico");
            DropIndex("dbo.ClienteServico", new[] { "EmpresaServico_idEmpresaServico" });
            RenameColumn(table: "dbo.ClienteServico", name: "EmpresaServico_idEmpresaServico", newName: "idEmpresaServico");
            AlterColumn("dbo.ClienteServico", "idEmpresaServico", c => c.Int(nullable: false));
            CreateIndex("dbo.ClienteServico", "idEmpresaServico");
            AddForeignKey("dbo.ClienteServico", "idEmpresaServico", "dbo.EmpresaServico", "idEmpresaServico", cascadeDelete: true);
            DropColumn("dbo.ClienteServico", "idServico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClienteServico", "idServico", c => c.Int(nullable: false));
            DropForeignKey("dbo.ClienteServico", "idEmpresaServico", "dbo.EmpresaServico");
            DropIndex("dbo.ClienteServico", new[] { "idEmpresaServico" });
            AlterColumn("dbo.ClienteServico", "idEmpresaServico", c => c.Int());
            RenameColumn(table: "dbo.ClienteServico", name: "idEmpresaServico", newName: "EmpresaServico_idEmpresaServico");
            CreateIndex("dbo.ClienteServico", "EmpresaServico_idEmpresaServico");
            AddForeignKey("dbo.ClienteServico", "EmpresaServico_idEmpresaServico", "dbo.EmpresaServico", "idEmpresaServico");
        }
    }
}
