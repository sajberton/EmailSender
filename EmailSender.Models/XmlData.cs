using System.Xml.Serialization;

namespace EmailSender.Models
{
    [XmlRoot("Clients")]
    public class Clients
    {
        [XmlElement("Client")]
        public List<XmlClient> ClientList { get; set; }
    }

    public class XmlClient
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlElement("Template")]
        public Template Template { get; set; }
    }

    public class Template
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("MarketingData")]
        public string MarketingData { get; set; }
    }
}
