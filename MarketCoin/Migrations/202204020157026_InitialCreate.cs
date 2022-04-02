namespace MarketCoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoinViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BaseAsset = c.String(nullable: false),
                        QuoteAsset = c.String(nullable: false),
                        LastPrice = c.Double(nullable: false),
                        Volumn24h = c.Double(nullable: false),
                        MarketId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoinViewModels");
        }
    }
}
