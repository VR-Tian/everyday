using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;
using WebApplication.Models.Dto;

/// <summary>
/// REST API/ Async / EF
/// </summary>
namespace WebApplication.Controllers
{
    public class OrderController : ApiController
    {

        public void Post()
        {
            try
            {
                using (CodeFirstContainer1 codeFirstContainer = new CodeFirstContainer1())
                {
                    Order order = new Order()
                    {
                        Status = OrderStatus.Created,
                        CreateDate = DateTime.UtcNow,
                        OrderNumer = "DT-" + DateTime.Now.Millisecond,
                        OrderItem = new List<OrderItem>() { new OrderItem() { Quantity = DateTime.Now.Second, Price = DateTime.Now.Millisecond } },
                    };

                    codeFirstContainer.Order.Add(order);
                    codeFirstContainer.SaveChanges();

                    //OrderItem orderItem = new OrderItem();
                    //Order order = new Order() { Id = ID, OrderItem = new List<OrderItem>() { new OrderItem() { Id = ID } } };
                    //codeFirstContainer.Order.Add(order);
                    //codeFirstContainer.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IHttpActionResult Get(Guid ID)
        {
            using (CodeFirstContainer1 codeFirstContainer = new CodeFirstContainer1())
            {
                var query = (from main in codeFirstContainer.Order
                             where main.Id == ID
                             select main).Include(x => x.OrderItem).ProjectTo<OrderDto>().FirstOrDefault();
                //var order = AutoMapper.Mapper.Map<Order, OrderDto>(query);
                //query.OrderItem.ToList().ForEach(f => order.OrderItem.Add(AutoMapper.Mapper.Map<OrderItem, OrderItemDto>(f)));
                return Ok(query);
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch(int ID)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int ID)
        {
            using (CodeFirstContainer1 codeFirstContainer = new CodeFirstContainer1())
            {
                return Ok(codeFirstContainer.Order.Find(ID));
            }
        }
    }
}
