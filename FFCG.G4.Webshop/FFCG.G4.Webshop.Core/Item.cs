using System;

namespace FFCG.G4.Webshop.Core
{
    public class Item
    {
        public string Id { get; }

        public Item()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
