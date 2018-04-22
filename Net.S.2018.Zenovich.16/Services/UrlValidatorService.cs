using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Models;

namespace Net.S._2018.Zenovich._16.Services
{
    public class UrlValidatorService : IUrlValidatorService
    {
        public static readonly string UrlPattern;

        public static readonly string SchemaPattern;

        public static readonly string HostPattern;

        public static readonly string ParameterPattern;

        public static readonly string SegmentPattern;

        static UrlValidatorService()
        {
            SchemaPattern = @"((ht|f)tp(s?))";
            HostPattern = @"([a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3})";
            SegmentPattern = @"([a-zA-Z0-9\-\.])";
            ParameterPattern = @"([a-zA-Z0-9\-\.)=[a-zA-Z0-9\-\.))";

            UrlPattern = $@"({SchemaPattern}\://){HostPattern}((/{SegmentPattern})+)?(({ParameterPattern}(&?))+)?";
        }

        public bool IsUrl(string url)
        {
            if (Regex.IsMatch(url, UrlPattern))
            {
                Url = new UrlAddressElement();
                Match match = Regex.Match(url, UrlPattern);

                Url.Schema = match.Groups[1].Value;
                Url.Host = match.Groups[2].Value;


                return true;
            }

            return false;
        }

        public UrlAddressElement Url { get; protected set; }

    }
}
