using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Services;

namespace Net.S._2018.Zenovich._16.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IUrlValidatorService urlValidatorService = new UrlValidatorService();

            string url = "https://github.com/AnzhelikaKravchuk?tab=repositories";

            if (urlValidatorService.IsUrl(url))
            {
                Console.WriteLine(urlValidatorService.Url.Schema);
                Console.WriteLine(urlValidatorService.Url.Host);
            }

            Console.ReadKey();
        }
    }
}
