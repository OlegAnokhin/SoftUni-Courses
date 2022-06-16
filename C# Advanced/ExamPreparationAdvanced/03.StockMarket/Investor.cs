using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.portfolio = new List<Stock>();
            this.fullName = fullName;
            this.emailAddress = emailAddress;
            this.moneyToInvest = moneyToInvest;
            this.brokerName = brokerName;
        }
        public int Count
        {
            get => this.portfolio.Count;
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && moneyToInvest >= stock.PricePerShare)
            {
                this.portfolio.Add(stock);
                MoneyToInvest -= stock.MarketCapitalization;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (Stock stock in this.portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    if (sellPrice < stock.PricePerShare)
                    {
                        return "Cannot sell " + companyName + ".";
                    }
                    else
                    {
                        this.portfolio.Remove(stock);
                        MoneyToInvest += sellPrice;
                        return companyName + " was sold.";
                    }
                }
            }
            return companyName + " does not exist.";
        }
        public Stock FindStock(string companyName)
        {
            foreach (Stock stock in this.portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return stock;
                }
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (this.portfolio.Count == null)
            {
                return null;
            }

            // return this.portfolio.OrderByDesending(....).First();
            Stock maxStock = null;
            decimal maxValue = 0;
            foreach (Stock stock in this.portfolio)
            {
                if (stock.MarketCapitalization > maxValue)
                {
                    maxValue = stock.MarketCapitalization;
                    maxStock = stock;
                }
            }
            return maxStock;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock stock in this.portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString();
        }
    }
}
