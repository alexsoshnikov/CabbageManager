namespace Cabbage_Manager_Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserEmail = c.String(),
                        DateRepresentation = c.String(),
                        UserBudget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserBudgets", t => t.UserBudget_Id)
                .Index(t => t.UserBudget_Id);
            
            CreateTable(
                "dbo.UserBudgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditCardSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserBudget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserBudgets", t => t.UserBudget_Id)
                .Index(t => t.UserBudget_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserBudget_Id", "dbo.UserBudgets");
            DropForeignKey("dbo.HistoryItems", "UserBudget_Id", "dbo.UserBudgets");
            DropIndex("dbo.Users", new[] { "UserBudget_Id" });
            DropIndex("dbo.HistoryItems", new[] { "UserBudget_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserBudgets");
            DropTable("dbo.HistoryItems");
        }
    }
}
