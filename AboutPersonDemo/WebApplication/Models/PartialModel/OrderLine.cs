using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public partial class OrderLine
    {
        /// <summary>
        /// 返回订单行商品总金额
        /// </summary>
        /// <remarks>
        /// 数量*销售价格-折扣
        /// </remarks>
        public decimal LineAmout
        {
            get
            {
                if (this.Order is SalesOrder)
                {
                    return this.Quantity * this.Item.SalesPrice - this.Discount;
                }
                else if (this.Order is ReturnOrder)
                {
                    return 0 - (this.Quantity * this.Item.SalesPrice - this.Discount);
                }
                return 0;
            }
        }

    }
}