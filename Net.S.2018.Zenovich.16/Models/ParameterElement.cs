using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Net.S._2018.Zenovich._16.Models
{
    [XmlRoot("parameter")]
    public class ParameterElement
    {
        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("key")]
        public string Key { get; set; }
    }
}
    