using System.Xml.Serialization;

namespace xmlTester.ConsoleApp.Models
{
    [XmlType(AnonymousType = false, Namespace = "http://ekassir.com/eKassir/PaySystem/Server/eKassirV3Protocol", TypeName = "GetDirectoryRequest")]
    [XmlRoot("Request", Namespace = "http://ekassir.com/eKassir/PaySystem/Server/eKassirV3Protocol", IsNullable = false)]
    public class PskbBalanceRequest
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces NameSpaces { get; } = new XmlSerializerNamespaces(new System.Xml.XmlQualifiedName[]
        {
            new System.Xml.XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new System.Xml.XmlQualifiedName("xsd", "http://www.w3.org/2001/XMLSchema")
        });

        public static PskbBalanceRequest Create()
        {
            return new PskbBalanceRequest
            {
                ServicesDetalization = 1,
                IncludeRegions       = false,
                IncludeServiceTypes  = false,
                IncludeContracts     = false,
                IncludeOperators     = false,
                IncludeCurrencies    = false,
                IncludeNominals      = false,
                RequestType          = "GetDirectoryRequest"
            };
        }

        [XmlAttribute("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string RequestType { get; set; }

        [XmlAttribute("ServicesDetalization")]
        public int ServicesDetalization { get; set; }
        [XmlAttribute("IncludeRegions")]
        public bool IncludeRegions { get; set; }
        [XmlAttribute("IncludeServiceTypes")]
        public bool IncludeServiceTypes { get; set; }
        [XmlAttribute("IncludeContracts")]
        public bool IncludeContracts { get; set; }
        [XmlAttribute("IncludeOperators")]
        public bool IncludeOperators { get; set; }
        [XmlAttribute("IncludeCurrencies")]
        public bool IncludeCurrencies { get; set; }
        [XmlAttribute("IncludeNominals")]
        public bool IncludeNominals { get; set; }
    }

}