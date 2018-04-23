using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Net.S._2018.Zenovich._16.Models
{
    [XmlRoot("urlAddress")]
    public class UrlAddressElement
    {
        [XmlElement("schema")]
        public string Schema { get; set; }

        [XmlElement("host")]
        public string Host { get; set; }

        [XmlArray("uri")]
        [XmlArrayItem("segment")]
        public List<string> Uri { get; set; }

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public List<ParameterElement> Parameters { get; set; }
    }
}
