using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Dto
{
    public class AddressDto
    {
    }
    public class InsertAddressDto
    {
        public string City { get; set; }

        public string Street { get; set; }
    }

    public class DeleteAddressDto
    {

        public string City { get; set; }

        public string Street { get; set; }
    }
}
