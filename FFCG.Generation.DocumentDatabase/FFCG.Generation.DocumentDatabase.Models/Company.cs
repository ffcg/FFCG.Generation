using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.Generation.DocumentDatabase.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
