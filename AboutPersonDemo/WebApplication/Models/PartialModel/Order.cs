using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.PartialModel;

namespace WebApplication.Models
{
    public partial class Order: IAggregateRoot
    {
        /// <summary>
        /// 该订单的数量总数
        /// </summary>
        /// <remarks>
        /// 领域行为ID：1
        /// </remarks>
        public Single TotalDiscount
        {
            get
            {
                return this.OrderLines.Sum(p => p.Discount);
            }
        }
        /// <summary>
        /// 该订单的明细总金额
        /// </summary>
        /// <remarks>
        /// 领域行为ID：2
        /// </remarks>
        public decimal TotalAmount
        {
            get
            {
                return this.OrderLines.Sum(p => p.LineAmout);
            }
        }

        public void GetOrderInfo(int id)
        {
            //TODO:获得指定订单的全部订单项
        }
    }
}