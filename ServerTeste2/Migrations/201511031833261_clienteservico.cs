namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clienteservico : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmpresaServicos", newName: "EmpresaServico");
            CreateTable(
                "dbo.ClienteServico",
                c => new
                    {
                        idClienteServico = c.Int(nullable: false, identity: true),
                        idCliente = c.Int(nullable: false),
                        idServico = c.Int(nullable: false),
                        statusServico = c.Int(nullable: false),
                        EmpresaServico_idEmpresaServico = c.Int(),
                    })
                .PrimaryKey(t => t.idClienteServico)
                .ForeignKey("dbo.Clientes", t => t.idCliente, cascadeDelete: true)
                .ForeignKey("dbo.EmpresaServico", t => t.EmpresaServico_idEmpresaServico)
                .Index(t => t.idCliente)
                .Index(t => t.EmpresaServico_idEmpresaServico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteServico", "EmpresaServico_idEmpresaServico", "dbo.EmpresaServico");
            DropForeignKey("dbo.ClienteServico", "idCliente", "dbo.Clientes");
            DropIndex("dbo.ClienteServico", new[] { "EmpresaServico_idEmpresaServico" });
            DropIndex("dbo.ClienteServico", new[] { "idCliente" });
            DropTable("dbo.ClienteServico");
            RenameTable(name: "dbo.EmpresaServico", newName: "EmpresaServicos");
        }
    }
}
