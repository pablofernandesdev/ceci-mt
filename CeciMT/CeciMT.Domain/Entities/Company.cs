using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeciMT.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string ApiKey { get; set; }

        public string DocumentNumber { get; set; }

        public ICollection<User> User { get; set; }
    }
}
