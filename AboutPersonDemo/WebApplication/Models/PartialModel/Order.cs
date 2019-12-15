using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public partial class Order
    {
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal OrderAmout
        {
            get { return this.OrderItem.Sum(t => t.ItemAmout); }
        }
    }
}