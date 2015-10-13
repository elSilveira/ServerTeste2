namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "geoLatitudeCliente", c => c.String(maxLength: 150));
            AddColumn("dbo.Clientes", "geoLongitudeCliente", c => c.String(maxLength: 150));
            AddColumn("dbo.Empresas", "geoLatitudeEmpresa", c => c.String(maxLength: 100));
            AddColumn("dbo.Empresas", "geoLongitudeEmpresa", c => c.String(maxLength: 100));
            AlterColumn("dbo.Clientes", "cidadeCliente", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clientes", "estadoCliente", c => c.String(maxLength: 150));
            AlterColumn("dbo.Empresas", "cidadeEmpresa", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresas", "estadoEmpresa", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresas", "ruaEmpresa", c => c.String(maxLength: 150));
            AlterColumn("dbo.Empresas", "bairroEmpresa", c => c.String(maxLength: 100));
            AlterColumn("dbo.Empresas", "cepEmpresa", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "cepEmpresa", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Empresas", "bairroEmpresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Empresas", "ruaEmpresa", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Empresas", "estadoEmpresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Empresas", "cidadeEmpresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clientes", "estadoCliente", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Clientes", "cidadeCliente", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Empresas", "geoLongitudeEmpresa");
            DropColumn("dbo.Empresas", "geoLatitudeEmpresa");
            DropColumn("dbo.Clientes", "geoLongitudeCliente");
            DropColumn("dbo.Clientes", "geoLatitudeCliente");
        }
    }
}
