using Microsoft.AspNetCore.Mvc;
using Order_Management.Models;
using System.Diagnostics;

namespace Order_Management.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1, int pageSize = 10, string sortColumn = "OrderId", bool sortAscending = true)
        {
            // Simulated list of orders (replace with your actual data)
            List<OrderList> allOrders = GetOrders();

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

        private List<OrderList> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            List<OrderList> orders = new List<OrderList>
        {
            new OrderList
            {
                OrderId = 1,
                SKU = "SKU123",
                ProductName = "Product A (Category 1)",
                Qty = 5,
                ShippingType = "Standard",
                TotalAmount = 99.95M,
                CustomerName = "John Doe",
                DOB = new DateTime(1990, 5, 15),
                Phone = "123-456-7890"
            },
            // Add more orders here
        };

            return View("OrderList",orders);
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult EditOrder()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteOrder()
        {
            return View();
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