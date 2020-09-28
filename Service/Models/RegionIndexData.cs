using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab2Service.Models
{
    //[DataContract(IsReference = true)]
    public class RegionIndexData
    {
        //[DataMember]
        public List<Region> Regions { get; set; }
        //[DataMember]
        public List<District> Districts { get; set; }
        //[DataMember]
        public List<Settlement> Settlements { get; set; }
    }
}