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

        [XmlArrayItem("uri")]
        public List<SegmentElement> Uri { get; set; }

        [XmlArrayItem("parameters")]
        public List<ParameterElement> Parameters { get; set; }
    }
}
