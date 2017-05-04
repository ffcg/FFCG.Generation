using System.Collections.Generic;

namespace FFCG.G5.Storage.Models
{
    public class Region
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Territory> Territories { get; set; }
    }
}