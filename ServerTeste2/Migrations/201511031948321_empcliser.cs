namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empcliser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpresaClienteServico",
                c => new
                    {
                        idEmpresaClienteServico = c.Int(nullable: false, identity: true),
                        idEmpresaCliente = c.Int(nullable: false),
                        idEmpresaServico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmpresaClienteServico)
                .ForeignKey("dbo.EmpresaCliente", t => t.idEmpresaCliente, cascadeDelete: false)
                .ForeignKey("dbo.EmpresaServico", t => t.idEmpresaServico, cascadeDelete: false)
                .Index(t => t.idEmpresaCliente)
                .Index(t => t.idEmpresaServico);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpresaClienteServico", "idEmpresaServico", "dbo.EmpresaServico");
            DropForeignKey("dbo.EmpresaClienteServico", "idEmpresaCliente", "dbo.EmpresaCliente");
            DropIndex("dbo.EmpresaClienteServico", new[] { "idEmpresaServico" });
            DropIndex("dbo.EmpresaClienteServico", new[] { "idEmpresaCliente" });
            DropTable("dbo.EmpresaClienteServico");
        }
    }
}
