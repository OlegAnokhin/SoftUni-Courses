using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;
        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
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
                MoneyToInvest -= stock.PricePerShare;
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
            if (this.portfolio.Count == 0)
            {
                return null;
            }
            return this.Portfolio
               .OrderByDescending(x => x.MarketCapitalization)
               .FirstOrDefault();
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
