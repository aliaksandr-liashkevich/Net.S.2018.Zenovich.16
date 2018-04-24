using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Net.S._2018.Zenovich._16.Models
{
    [XmlRoot("urlRoot")]
    public class UrlAddressesRoot
    {
        [XmlArray("urlAddresses")]
        [XmlArrayItem("urlAddress")]
        public List<UrlAddressElement> UrlAddresses { get; set; }
    }
}
