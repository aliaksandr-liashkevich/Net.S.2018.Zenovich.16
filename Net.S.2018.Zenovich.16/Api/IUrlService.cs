using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._16.Api
{
    public interface IUrlService : IDisposable
    {
        void AddElements(string filePath);
    }
}
