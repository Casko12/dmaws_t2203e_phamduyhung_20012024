using dmaws_20012024.dto;
using dmaws_20012024.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dmaws_20012024.Controllers
{
    [Route("v1/api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderSystemContext _context;

        public OrderController(OrderSystemContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<OrderTbl>> CreateOrder(OrderTbl createOrder)
        {
            var order = new OrderTbl();

            order.ItemName = createOrder.ItemName;
            order.ItemQty = createOrder.ItemQty;
            order.OrderAddress = createOrder.OrderAddress;
            order.OrderDelivery = createOrder.OrderDelivery;
            order.PhoneNumber = createOrder.PhoneNumber;

            _context.OrderTbls.Add(order);
            await _context.SaveChangesAsync();

            return Created("Success", order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrder updateOrder)
        {
            var orderExists = _context.OrderTbls.Any(e => e.ItemCode == id);
            if (!orderExists)
            {
                return BadRequest();
            }

            var order = await _context.OrderTbls.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderAddress = updateOrder.OrderAddress;
            order.PhoneNumber = updateOrder.PhoneNumber;

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderExists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
