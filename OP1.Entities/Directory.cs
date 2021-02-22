using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP1.Entities
{
   public class Directory
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumberI { get; set; }
        public string PhoneNumberII { get; set; }
        public string PhoneNumberIII { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
