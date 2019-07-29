using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer : EntityBase
    {
        public Customer() : this(0)// constructor chaining default contructor calls the other constructor and the adress list is always constructed
        {

        }

        public Customer (int customerId)
        {
            CustomerId = customerId; // set the custoemrId with the constructor 
            // create a instance of the address list so that 
            AddressList = new List<Address>(); // without this we will return null exception error   

        }
        /// <summary>
        /// overall this explains Encapsulation 
        /// </summary>
        //short syntax  behind the scene the code is  creating the backing field. 
        /*if there is no need for logic in the getter or setter*/
        public List<Address> AddressList { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        // prop tab tab  
        // any class can get the CustomerId but only this class can set it. 
        public int CustomerId { get; private set; }//propg
        public int CustomerType { get; set; }
        //no backing feild or setter no other code would change this value and we are using variables that already have backing fields
        public string FullName
        {
            get
            {
                string fullName = LastName; 
                if(!string.IsNullOrWhiteSpace(FirstName))
                {
                    if(!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName; 

            }
        }
        //static modifier denotes that the member belongs to the class itself rather than to any specific instance
        public static int InstanceCount { get; set; }
        //this variable is the backing field
        private string _lastName; // private access modifier  
        public string LastName
        {
            get
            {
                return _lastName; 
            }
            set
            {
                _lastName = value; 
            }
        }
        //Add methods here 
        public override string ToString() => FullName;

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns>bool</returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid; 
        }

    }
}
