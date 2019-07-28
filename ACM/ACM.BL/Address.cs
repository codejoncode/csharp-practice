using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    class Address
    {
        public Address()
        {

        }

        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }

        ///<summary>
        ///Validates the address
        /// </summary>
        /// <returns>bool</returns>
        /// 
        public bool Validate ()
        {
            //code for validation  
            // which parts are required for the user to have updated ? 
            return true; 
        }

    }
}
