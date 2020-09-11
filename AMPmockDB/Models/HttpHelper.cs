using AMPmockDB.DBContext;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;

namespace AMPmockDB.Models
{
    public class HttpHelper
    {
        public static double getPortfolioReturn(Portfolio portfolio)
        {
            var portfolioReturn = 0.0;
            var sumOfShares = portfolio.Asset.Select(e => e.Asset_nbShare).Sum();
            using (var client = new HttpClient())
            {
                foreach (var asset in portfolio.Asset)
                {
                    client.BaseAddress = new Uri("https://financialmodelingprep.com");
                    var result = client.GetAsync("/api/v3/ratios/" + asset.Asset_ticker + "? apikey=demo").Result;
                    result.EnsureSuccessStatusCode();
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    JObject resultContent = JObject.Parse(resultString);
                    var roa = Convert.ToDouble(resultContent["returnOnAssets"]);
                    portfolioReturn = + (roa * (asset.Asset_nbShare / sumOfShares));
                }
                return portfolioReturn;
            }
        }

        public static double getPortfolioBeta(Portfolio portfolio)
        {
            var portfolioBeta = 0.0;
            var sumOfShares = portfolio.Asset.Select(e => e.Asset_nbShare).Sum();
            using (var client = new HttpClient())
            {
                foreach (var asset in portfolio.Asset)
                {
                    client.BaseAddress = new Uri("https://financialmodelingprep.com");
                    var result = client.GetAsync("/api/v3/profile/" + asset.Asset_ticker + "? apikey=demo").Result;
                    result.EnsureSuccessStatusCode();
                    string resultString = result.Content.ReadAsStringAsync().Result;
                    JObject resultContent = JObject.Parse(resultString);
                    var beta = Convert.ToDouble(resultContent["beta"]);
                    portfolioBeta = +(beta * (asset.Asset_nbShare / sumOfShares));
                }
                return portfolioBeta;
            }
        }
    }
}