namespace MarketCoin.Migrations
{
    using MarketCoin.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MarketCoin.Data.MarketCoinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MarketCoin.Data.MarketCoinContext";
        }

        protected override void Seed(MarketCoin.Data.MarketCoinContext context)
        {
            IList<Coin> coins = new List<Coin>();

            coins.Add(new Coin()
            {
                Name = "BTC",
                BaseAsset = "BTC/USD",
                QuoteAsset = "BTC/USD",
                LastPrice = 100,
                Volumn24h = 3000,
                Status = 1
            });

            coins.Add(new Coin()
            {
                Name = "USD",
                BaseAsset = "ETC/USD",
                QuoteAsset = "AVAX/USD",
                LastPrice = 1000,
                Volumn24h = 30000,
                Status = 2
            });

            coins.Add(new Coin()
            {
                Name = "EOS",
                BaseAsset = "LTC/USD",
                QuoteAsset = "AVAX/USD",
                LastPrice = 10000,
                Volumn24h = 3000000,
                Status = 3
            });

            foreach (Coin coin in coins)
                context.Coins.Add(coin);
            base.Seed(context);
        }
    }
}
