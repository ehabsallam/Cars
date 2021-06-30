namespace Jobs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsecuritytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Securities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Securities");
        }
    }
}
