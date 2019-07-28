using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    class Product
    {
        // constructor 
        public Product()
        {

        }
        //overloaded constructor 
        public Product(int productId)
        {
            ProductId = productId; 
        }
        // the ? denotes a nullable type  integer or decimal can be set or  not set  
        public decimal? CurrentPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductId { get; private set; }
        public string ProductName { get; set; }

        /// <summary>
        /// Retrieve one product. 
        /// </summary>
        /// <returns>Product</returns>
        public Product Retrieve(int customerId)
        {
            //Code that retrieves the defined product

            return new Product();
        }
        /// <summary>
        /// Saves the current product.
        /// </summary>
        /// <returns>bool</returns
        public bool  Save()
        {
            // Code that saves the defined product 

            return true; 
        }
        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns>bool</returns>
        /// 
        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid; 
        }
    }
}
