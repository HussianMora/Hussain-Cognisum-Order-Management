using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order_Management.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderBL.Interface;

namespace Order_Management.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderBAL _orderBAL;

        public OrderController(ILogger<OrderController> logger, IOrderBAL orderBAL)
        {
            _logger = logger;
            _orderBAL = orderBAL;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string sortColumn = "OrderId", bool sortAscending = true)
        {
            // Get a list of orders asynchronously from the business layer
            List<OrderList> allOrders = await _orderBAL.GetAllOrdersAsync();

            // Sorting
            if (!string.IsNullOrEmpty(sortColumn))
            {
                allOrders = SortOrders(allOrders, sortColumn, sortAscending);
            }

            // Pagination
            int totalItems = allOrders.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            List<OrderList> orders = allOrders
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new OrderListViewModel
            {
                Orders = orders,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                SortColumn = sortColumn,
                SortAscending = sortAscending
            };

            return View("OrderList", viewModel);
        }

        private List<OrderList> SortOrders(List<OrderList> orders, string sortColumn, bool sortAscending)
        {
            switch (sortColumn)
            {
                case "OrderId":
                    return sortAscending ? orders.OrderBy(o => o.OrderId).ToList() : orders.OrderByDescending(o => o.OrderId).ToList();
                case "SKU":
                    return sortAscending ? orders.OrderBy(o => o.SKU).ToList() : orders.OrderByDescending(o => o.SKU).ToList();
                case "ProductName":
                    return sortAscending ? orders.OrderBy(o => o.ProductName).ToList() : orders.OrderByDescending(o => o.ProductName).ToList();
                case "Qty":
                    return sortAscending ? orders.OrderBy(o => o.Qty).ToList() : orders.OrderByDescending(o => o.Qty).ToList();
                case "ShippingType":
                    return sortAscending ? orders.OrderBy(o => o.ShippingType).ToList() : orders.OrderByDescending(o => o.ShippingType).ToList();
                case "TotalAmount":
                    return sortAscending ? orders.OrderBy(o => o.TotalAmount).ToList() : orders.OrderByDescending(o => o.TotalAmount).ToList();
                // Add cases for other columns here
                default:
                    return orders;
            }
        }

        public async Task<IActionResult> Index()
        {
            // Get a list of orders asynchronously from the business layer
            List<OrderList> orders = await _orderBAL.GetAllOrdersAsync();

            return View("OrderList", orders);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Call the business layer asynchronously to add the order
                await _orderBAL.AddOrderAsync(order);
                return RedirectToAction("OrderSubmitted");
            }

            return View(order);
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditOrder(int orderId)
        {
            // Get the order by ID from the business layer
            var order = await _orderBAL.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                // Handle not found case
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // Call the business layer asynchronously to update the order
                await _orderBAL.UpdateOrderAsync(order);
                return RedirectToAction("OrderUpdated");
            }

            return View(order);
        }

        [HttpGet]
        public IActionResult DeleteOrder(int orderId)
        {
            // Get the order by ID from the business layer
            var order = await _orderBAL.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                // Handle not found case
                return NotFound();
            }

            return View(order);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
