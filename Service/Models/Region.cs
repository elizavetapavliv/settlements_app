using System.Collections.Generic;

namespace Lab2Service.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public List<District> Districts { get; set; }
    }
}