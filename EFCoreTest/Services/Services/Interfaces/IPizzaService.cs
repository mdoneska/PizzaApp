using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels.PizzaViewModels;

namespace Services.Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAll();
        string GetPizzaOnPromotion();
    }
}
