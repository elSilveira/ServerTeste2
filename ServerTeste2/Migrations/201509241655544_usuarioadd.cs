namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        idCliente = c.Int(nullable: false),
                        senhaUsuario = c.String(maxLength: 200),
                        roleUsuario = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Clientes", t => t.idCliente, cascadeDelete: true)
                .Index(t => t.idCliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Usuarios", new[] { "idCliente" });
            DropTable("dbo.Usuarios");
        }
    }
}
