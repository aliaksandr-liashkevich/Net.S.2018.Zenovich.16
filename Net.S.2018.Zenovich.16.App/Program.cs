using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Repositories;
using Net.S._2018.Zenovich._16.Services;

namespace Net.S._2018.Zenovich._16.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IUrlParserService urlParserService = new UrlParserService();

            // string url = "https://github.com/AnzhelikaKravchuk?tab=repositories";
            string url = "https://github.com/AnzhelikaKravchuk/Alexander/Boboasd?key=value&qwe=123&qweqwe=asads";

            if (urlParserService.IsUrl(url))
            {
               Console.WriteLine(urlParserService.Url.Schema);
               Console.WriteLine(urlParserService.Url.Host);
            }

            UrlService urlService = new UrlService(new UrlRepository(), new UrlParserService());

            
            urlService.AddElements(null);
            urlService.Dispose();


            Console.ReadKey();
        }
    }
}
