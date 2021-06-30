namespace Jobs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "JobId" });
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            CreateTable(
                "dbo.buyCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        CarId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarTitle = c.String(),
                        CarContent = c.String(),
                        CarImage = c.String(),
                        UserId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.EditProfileViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CurrentPassword = c.String(nullable: false, maxLength: 100),
                        NewPassword = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ApplyForJobs");
            DropTable("dbo.Jobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobContent = c.String(),
                        JobImage = c.String(),
                        UserId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.buyCars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.buyCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropIndex("dbo.buyCars", new[] { "UserId" });
            DropIndex("dbo.buyCars", new[] { "CarId" });
            DropTable("dbo.EditProfileViewModels");
            DropTable("dbo.Cars");
            DropTable("dbo.buyCars");
            CreateIndex("dbo.Jobs", "CategoryId");
            CreateIndex("dbo.Jobs", "UserId");
            CreateIndex("dbo.ApplyForJobs", "UserId");
            CreateIndex("dbo.ApplyForJobs", "JobId");
            AddForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
