﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem : EntityBase
    {
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Retrieve one order item. 
        /// </summary>
        /// <returns>OrderItem</returns>
        /// 
        public OrderItem Retrieve(int orderItemId)
        {
            //Code that retrieves the defined order item 

            return new OrderItem();
        }

        /// <summary>
        /// Saves the current order item. 
        /// </summary>
        /// <returns></returns>
        /// 
        public bool Save()
        {
            //Code that saves the defined order item 
            return true; 
        }
        /// <summary>
        /// Validates the order item data. 
        /// </summary>
        /// <returns>bool</returns>
        /// 
        public override bool Validate()
        {
            var isValid = true;

            if (Quantity <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid; 
        }
    }
}
