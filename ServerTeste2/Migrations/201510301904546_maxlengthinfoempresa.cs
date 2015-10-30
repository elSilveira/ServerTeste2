namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxlengthinfoempresa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresas", "infoEmpresa", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "infoEmpresa", c => c.String());
        }
    }
}
