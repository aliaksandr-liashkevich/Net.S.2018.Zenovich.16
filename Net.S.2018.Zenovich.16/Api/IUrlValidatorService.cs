using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Models;

namespace Net.S._2018.Zenovich._16.Api
{
    public interface IUrlValidatorService
    {
        bool IsUrl(string url);

        UrlAddressElement Url { get; }
    }
}
