using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Models;

namespace Net.S._2018.Zenovich._16.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        public const string DefaultPath = "UrlAddresses.xml";

        public static readonly string FilePath;

        private UrlAddressesRoot root;

        private readonly XmlSerializer serializer;

        static UrlRepository()
        {
            FilePath = DefaultPath;
        }

        public UrlRepository()
        {
            root = new UrlAddressesRoot();
            root.UrlAddresses = new List<UrlAddressElement>();
            serializer = new XmlSerializer(typeof(UrlAddressesRoot));
        }

        public void Add(UrlAddressElement element)
        {
            root.UrlAddresses.Add(element);
        }

        public IEnumerable<UrlAddressElement> GetAll()
        {
            return root.UrlAddresses;
        }

        public void Save()
        {
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, root);
            }
        }
    }
}
