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
    /// <summary>
    /// Implements data operation.
    /// </summary>
    /// <seealso cref="Net.S._2018.Zenovich._16.Api.IUrlRepository" />
    public class UrlRepository : IUrlRepository
    {
        #region Fields

        public const string DefaultPath = "UrlAddresses.xml";

        public static readonly string FilePath;

        private readonly XmlSerializer serializer;

        private UrlAddressesRoot root;

        #endregion Fields

        #region Ctor

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

        #endregion Ctor

        #region Public methods

        /// <summary>
        /// Adds the specified url element.
        /// </summary>
        /// <param name="element">The url.</param>
        public void Add(UrlAddressElement element)
        {
            root.UrlAddresses.Add(element);
        }

        /// <summary>
        /// Gets list url.
        /// </summary>
        /// <returns>list url.</returns>
        public IEnumerable<UrlAddressElement> GetAll()
        {
            return root.UrlAddresses;
        }

        /// <summary>
        /// Saves the list url in xml-file.
        /// </summary>
        public void Save()
        {
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, root);
            }
        }

        #endregion Public methods
    }
}
