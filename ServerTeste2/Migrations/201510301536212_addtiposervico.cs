namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtiposervico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicos", "tipoServico", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicos", "tipoServico");
        }
    }
}
