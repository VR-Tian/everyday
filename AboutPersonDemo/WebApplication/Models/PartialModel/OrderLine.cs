using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.PartialModel;

namespace WebApplication.Models
{
    public partial class OrderLine: IEntity
    {
        /// <summary>
        /// 返回当前订单项的总金额
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