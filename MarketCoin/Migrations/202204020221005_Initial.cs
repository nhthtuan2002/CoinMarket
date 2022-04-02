namespace MarketCoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CoinViewModels", newName: "Coins");
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Coins", "MarketId_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Coins", "MarketId_Id");
            AddForeignKey("dbo.Coins", "MarketId_Id", "dbo.Markets", "Id", cascadeDelete: true);
            DropColumn("dbo.Coins", "MarketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coins", "MarketId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Coins", "MarketId_Id", "dbo.Markets");
            DropIndex("dbo.Coins", new[] { "MarketId_Id" });
            DropColumn("dbo.Coins", "MarketId_Id");
            DropTable("dbo.Markets");
            RenameTable(name: "dbo.Coins", newName: "CoinViewModels");
        }
    }
}
