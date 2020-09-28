using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lab2Service.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        [XmlIgnore]
        public Region Region { get; set; }
        public List<Settlement> Settlements { get; set; }
    }
}