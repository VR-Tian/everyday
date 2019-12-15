using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public partial class OrderItem
    {
        /// <summary>
        /// 明细金额
        /// </summary>
        public decimal ItemAmout
        {
            get { return this.Price * this.Quantity; }
        }
    }
}