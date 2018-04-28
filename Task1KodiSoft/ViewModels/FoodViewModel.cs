using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1KodiSoft.ViewModels
{
    public class FoodViewModel
    {
        public List<FoodItemViewModel> TopOrders { get; set; }
        public List<FoodItemViewModel> Unordered { get; set; }
    }
}
