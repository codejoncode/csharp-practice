using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Address
    {
        public Address()
        {

        }
        public Address(int addressId)
        {
            AddressId = addressId;
        }
        public int AddressId { get; private set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int AddressType { get; set; }

        ///<summary>
        ///Validates the address data
        /// </summary>
        /// <returns>bool</returns>
        /// 
        public bool Validate ()
        {
            var isValid = true;

            if (PostalCode == null) isValid = false; 

            return isValid; 
        }

    }
}
