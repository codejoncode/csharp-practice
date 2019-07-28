using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer
    {
        /// <summary>
        /// overall this explains Encapsulation 
        /// </summary>
        //short syntax  behind the scene the code is  creating the backing field. 
        /*if there is no need for logic in the getter or setter*/
        public string Firstname { get; set; }
        public string EmailAddress { get; set; }
        // prop tab tab  
        // any class can get the CustomerId but only this class can set it. 
        public int CustomerId { get; private set; }//propg

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
    }
}
