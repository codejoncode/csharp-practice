﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class AddressRepository
    {
        /// <summary>
        /// REtrieve a address 
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public Address Retrieve(int addressId)
        {
            //Create the instance of the Address class 
            //Pass in the requested id 
            Address address = new Address(addressId);

            //Code that retrieves the defined address 

            //Temporary hard coded values to return a
            // populated address 
            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Bag End";
                address.StreetLine2 = "Bagshot row";
                address.City = "Hobbiton";
                address.StateProvince = "shire";
                address.Country = "Middle Earth";
                address.PostalCode = "144";
            }

            return address; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        public IEnumerable<Address> RetrieveByCustomerId (int customerid)
        {
            //Code that retrieves the defined addresses 
            // For the customer. 

            //Temporary hard-coded values to return  
            //a set of addresses for a customer 
            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                StateProvince = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Green Dragon",
                City = "Bywater",
                StateProvince = "Shire",
                Country = "Middle Earth",
                PostalCode = "146"
            };
            addressList.Add(address);

            return addressList;
        }


        /// <summary>
        /// save a address 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool Save(Address address)
        {
            // Code to save a address  

            return true; 
        }
    }
}
