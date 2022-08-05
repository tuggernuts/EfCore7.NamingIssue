using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EfCore7.NamingIssue.Domain
{
    public class Aircraft
    {
        public int Id { get; set; }
        public Company Owner { get; set; }
        public int OwnerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public string ModelNumber { get; set; }
        public string CommonName { get; set; }

        public int EngineCount { get; set; }
    }
}
