using Microsoft.AspNetCore.Mvc;
using PizzaApp05.Models;
using Services.Services.Interfaces;
using ViewModels.ViewModels;
using ViewModels.ViewModels.PizzaViewModels;

namespace PizzaApp05.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly IOrderService _orderService;
        public PizzaController(IPizzaService pizzaService, IOrderService orderService)
        {
            _pizzaService = pizzaService;
            _orderService = orderService;
        }

        public IActionResult Index() //localhost:[port]/Pizza
        {
            List<PizzaViewModel> viewModels = _pizzaService.GetAll();
            return View(viewModels);
        }

        public IActionResult AddPizza(int id)
        {
            PizzaOrderViewModel pizzaOrderViewModel = new PizzaOrderViewModel();
            pizzaOrderViewModel.OrderId = id;
            ViewBag.Pizzas = _pizzaService.GetAll();
            return View(pizzaOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddPizza(PizzaOrderViewModel pizzaOrderViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(pizzaOrderViewModel);
                return RedirectToAction("Details", "Order", new { id = pizzaOrderViewModel.OrderId });
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }
    }
}
