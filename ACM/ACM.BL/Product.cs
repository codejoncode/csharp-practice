﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
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

        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName.InsertSpaces();// due to way of extension in the String Hanlder file
            }
            set
            {
                _productName = value; 
            }
        }

        


        public override string ToString() => ProductName;

        public string Log() => $"{ProductId}: {ProductName} Detail: {ProductDescription} Status: {EntityState.ToString()}";
       

        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns>bool</returns>
        /// 
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid; 
        }
    }
}
