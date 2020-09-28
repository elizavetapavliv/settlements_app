using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Lab2Service.Models
{
    public class Settlement
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int Population { get; set; }
        public int DistrictId { get; set; }
        [XmlIgnore]
        public District District { get; set; }
    }
}