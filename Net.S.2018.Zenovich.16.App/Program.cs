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
            using (var service = new UrlService(new UrlRepository(), new UrlParserService()))
            {
                service.AddElements("urls.txt");
            }

            Console.ReadKey();
        }
    }
}
