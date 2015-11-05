namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoservicoempresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClienteServico", "valorServico", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClienteServico", "valorServico");
        }
    }
}
