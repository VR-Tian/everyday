using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumer { get; set; }
        public System.DateTime CreateDate { get; set; }

        public List<OrderItemDto> OrderItem { get; set; }
    }
}