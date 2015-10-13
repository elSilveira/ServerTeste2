namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientTelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "telefoneCliente", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "telefoneCliente");
        }
    }
}
