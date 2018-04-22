using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Models;

namespace Net.S._2018.Zenovich._16.Api
{
    public interface IUrlRepository
    {
        void Add(UrlAddressElement element);

        IEnumerable<UrlAddressElement> GetAll();

        void Save();
    }
}
