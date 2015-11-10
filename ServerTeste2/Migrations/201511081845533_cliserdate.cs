namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliserdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClienteServico", "dataServico", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClienteServico", "dataAlternativa", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClienteServico", "dataResposta", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClienteServico", "dataResposta");
            DropColumn("dbo.ClienteServico", "dataAlternativa");
            DropColumn("dbo.ClienteServico", "dataServico");
        }
    }
}
