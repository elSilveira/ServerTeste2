namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoagenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        idAgenda = c.Int(nullable: false, identity: true),
                        horarioAgenda = c.DateTime(nullable: false),
                        idEmpresa = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        idFuncionario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAgenda)
                .ForeignKey("dbo.Clientes", t => t.idCliente, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.idEmpresa, cascadeDelete: true)
                .Index(t => t.idEmpresa)
                .Index(t => t.idCliente);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        nomeCliente = c.String(nullable: false, maxLength: 150),
                        sobrenomeCliente = c.String(nullable: false, maxLength: 150),
                        emailCliente = c.String(nullable: false, maxLength: 150),
                        cidadeCliente = c.String(nullable: false, maxLength: 150),
                        estadoCliente = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.idCliente)
                .Index(t => t.emailCliente, unique: true);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        idEmpresa = c.Int(nullable: false, identity: true),
                        nomeEmpresa = c.String(nullable: false, maxLength: 150),
                        cidadeEmpresa = c.String(nullable: false, maxLength: 100),
                        estadoEmpresa = c.String(nullable: false, maxLength: 100),
                        ruaEmpresa = c.String(nullable: false, maxLength: 150),
                        bairroEmpresa = c.String(nullable: false, maxLength: 100),
                        cepEmpresa = c.String(nullable: false, maxLength: 10),
                        numeroEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmpresa);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.EmpresaCliente",
                c => new
                    {
                        idEmpresaCliente = c.Int(nullable: false, identity: true),
                        idEmpresa = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        tipoCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmpresaCliente)
                .ForeignKey("dbo.Clientes", t => t.idCliente, cascadeDelete: true)
                .ForeignKey("dbo.Empresas", t => t.idEmpresa, cascadeDelete: true)
                .Index(t => t.idEmpresa)
                .Index(t => t.idCliente);
            
            CreateTable(
                "dbo.EmpresaServicos",
                c => new
                    {
                        idEmpresaServico = c.Int(nullable: false, identity: true),
                        idEmpresa = c.Int(nullable: false),
                        idServico = c.Int(nullable: false),
                        tempoServico = c.Int(nullable: false),
                        valorServico = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idEmpresaServico)
                .ForeignKey("dbo.Empresas", t => t.idEmpresa, cascadeDelete: true)
                .ForeignKey("dbo.Servicos", t => t.idServico, cascadeDelete: true)
                .Index(t => t.idEmpresa)
                .Index(t => t.idServico);
            
            CreateTable(
                "dbo.Servicos",
                c => new
                    {
                        idServico = c.Int(nullable: false, identity: true),
                        nomeServico = c.String(nullable: false, maxLength: 150),
                        idCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idServico)
                .ForeignKey("dbo.Categorias", t => t.idCategoria, cascadeDelete: true)
                .Index(t => t.idCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpresaServicos", "idServico", "dbo.Servicos");
            DropForeignKey("dbo.Servicos", "idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.EmpresaServicos", "idEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaCliente", "idEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaCliente", "idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Agenda", "idEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Servicos", new[] { "idCategoria" });
            DropIndex("dbo.EmpresaServicos", new[] { "idServico" });
            DropIndex("dbo.EmpresaServicos", new[] { "idEmpresa" });
            DropIndex("dbo.EmpresaCliente", new[] { "idCliente" });
            DropIndex("dbo.EmpresaCliente", new[] { "idEmpresa" });
            DropIndex("dbo.Clientes", new[] { "emailCliente" });
            DropIndex("dbo.Agenda", new[] { "idCliente" });
            DropIndex("dbo.Agenda", new[] { "idEmpresa" });
            DropTable("dbo.Servicos");
            DropTable("dbo.EmpresaServicos");
            DropTable("dbo.EmpresaCliente");
            DropTable("dbo.Categorias");
            DropTable("dbo.Empresas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Agenda");
        }
    }
}
