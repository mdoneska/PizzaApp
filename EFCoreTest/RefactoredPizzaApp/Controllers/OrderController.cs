using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using PizzaApp05.Models;
using Services.Mappers;
using Services.Services.Concretes;
using Services.Services.Interfaces;
using ViewModels.ViewModels;

namespace PizzaApp05.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }   
        public IActionResult Index() //localhost:[port]/Order
        {
            List<OrderListViewModel> viewModels = _orderService.GetAllOrders();
            return View(viewModels);
        }

        public IActionResult Details(int? id) //localhost:[port]/Order/Details/1
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
            return View(orderDetailsViewModel);
        }

        public IActionResult CreateOrder() //localhost:[port]/Order/CreateOrder
        {
            // We have to send an empty model so that the form data is packed into that kind of model when it is sent via post
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id) //localhost:[port]/Order/EditOrder/1
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            ViewBag.Users = _userService.GetUsersForDropdown();
            OrderViewModel orderViewModel = _orderService.GetOrderForEditing(id.Value);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrder(OrderViewModel orderViewModel)
        {
            _orderService.EditOrder(orderViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) //localhost:[port]/Order/Delete/1
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
            return View(orderDetailsViewModel);
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            _orderService.DeleteOrder(id.Value);
            return RedirectToAction("Index");
        }
    }
}
